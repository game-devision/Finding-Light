using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float SlopeCheckDistance;

    private bool slopePulse = true;
    private bool isOnSlope;
    private Vector2 coliderSize;
    private CapsuleCollider2D cc;
    private float slopeDownAngle;
    private float slopeDownAngleOld;
    private Vector2 slopeNormalPerp;
    private float horizontal;
    private float speed = 8f;
    private float jumpHight = 10f;
    private bool Dir = true;
    public Rigidbody2D rb;
    public bool IsGrounded;
    public GameObject groundCheck;
    [SerializeField] GameObject Attack;
    private bool AttackCoolDown = false;
    private bool DashCoolDown = false;
    public bool isDashing = false;
    public int ammo = 12;
    public int maxAmmo = 12;
    public TMP_Text bulletCount;
    public Transform ShootPoint;
    public GameObject bullet;
    bool IsShooting = false;
    public GameObject trail;
    public bool _movementLock = false;
    [SerializeField]LayerMask groundLayer;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Attack.SetActive(false);    
        trail.SetActive(false);
        cc = GetComponent<CapsuleCollider2D>();
        coliderSize = cc.size;
        
    }
    void Update()
    {
        
        if(isOnSlope && horizontal == 0 && slopePulse){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            slopePulse = false;
        }
         if(isOnSlope && horizontal == 0){
            rb.velocity = new Vector2(0, rb.velocity.y);
         }
        if(horizontal !=0){
            slopePulse = true;
        }
        SlopeCheck();
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpHight);
            IsGrounded = false;
        }    
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); 
            isOnSlope  = false;
        }
        if (rb.velocity.y < 0){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + -0.1f);
            
        }
        if (Input.GetButtonDown("Fire1")){
            StartCoroutine("PlayerAttack");
        }
        if (Input.GetKeyDown(KeyCode.Z)){
            StartCoroutine("Dash");
        }
        if (isDashing){
            Dash2();
        }
        SpriteFlip();
        if (ammo > maxAmmo){
            ammo = maxAmmo;
        }
        bulletCount.text = ammo.ToString();
        if (Input.GetKeyDown(KeyCode.Q) && ammo > 0){
            StartCoroutine("Shoot");
            print("test");
        }
        if(_movementLock){
            rb.velocity = new Vector2(0, 0);
        }
    }
    IEnumerator Dash(){
        if (!DashCoolDown && IsGrounded){
            print("Dash");
            trail.SetActive(true);         
            DashCoolDown = true;
            isDashing = true;
            yield return new WaitForSeconds(0.3f);
            isDashing = false;
            trail.SetActive(false);
            yield return new WaitForSeconds(0.7f);    
            DashCoolDown = false;
            
        }
    }
    void Dash2(){
        rb.AddForce(rb.velocity * 7);
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }
    private void FixedUpdate(){
        if(!_movementLock){
        if(IsGrounded && !isOnSlope){
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            print("ground no slope");
        } else if(IsGrounded && isOnSlope){
            rb.velocity = new Vector2(speed * slopeNormalPerp.x * -horizontal, speed * slopeNormalPerp.y * -horizontal);
            print("slope");
        } else if(!IsGrounded){
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            print("air");
        }
        
        
        }
        
    }
     IEnumerator PlayerAttack(){
        if (!AttackCoolDown){
        _movementLock = true;
        
        print("Oh where is my loveer");
        AttackCoolDown = true;
        Attack.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Attack.SetActive(false);
        _movementLock = false;
        yield return new WaitForSeconds(0.3f);
        AttackCoolDown = false;
        }

        
    }

    
    private void SpriteFlip(){
        if (Dir && horizontal < 0f || !Dir && horizontal > 0f){
            Dir = !Dir;
            transform.Rotate(0,180, 0);
            Attack.SetActive(false);
            /*
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            
            */
        }
    }
    IEnumerator Shoot(){
        if (!IsShooting){
        IsShooting = true;
        Instantiate(bullet, ShootPoint.position, transform.rotation);
        ammo -= 1;
        yield return new WaitForSeconds(0.2f);
        IsShooting = false;
        }
    }
    private void SlopeCheck(){
        Vector2 checkPos = transform.position - new Vector3(0.0f, coliderSize.y/2);
        SlopeCheckVertical(checkPos);
        SlopeCheckHorizontal(checkPos);
    }
    private void SlopeCheckHorizontal(Vector2 groundCheck){

    }
    
    private void SlopeCheckVertical(Vector2 checkPos){
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, SlopeCheckDistance, groundLayer);
        if(hit){
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            Debug.DrawLine(hit.point, hit.normal, Color.green);
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);
            Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);
            if(hit.normal != new Vector2(0, 1)){
                isOnSlope = true;
            } else {
                isOnSlope = false;
            }
            slopeDownAngleOld = slopeDownAngle;
            print(hit.normal);
        }
    }
}

