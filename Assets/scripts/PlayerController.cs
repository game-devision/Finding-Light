using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpHight = 10f;
    private bool Dir = true;
    private Rigidbody2D rb;
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

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Attack.SetActive(false);    
        
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpHight);
        }    
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); 
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
    }
    IEnumerator Dash(){
        if (!DashCoolDown && IsGrounded){
            print("Dash");
            DashCoolDown = true;
            isDashing = true;
            yield return new WaitForSeconds(0.3f);
            isDashing = false;
            yield return new WaitForSeconds(0.7f);    
            DashCoolDown = false;
            
        }
    }
    void Dash2(){
        rb.AddForce(rb.velocity * 7);
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }
    private void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
     IEnumerator PlayerAttack(){
        if (!AttackCoolDown){
        AttackCoolDown = true;
        Attack.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Attack.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        AttackCoolDown = false;
        }

        
    }

    
    private void SpriteFlip(){
        if (Dir && horizontal < 0f || !Dir && horizontal > 0f){
            Dir = !Dir;
            transform.Rotate(0,180, 0);
            /*
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            Attack.SetActive(false);
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
}
