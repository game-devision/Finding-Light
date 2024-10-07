using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_1 : MonoBehaviour
{
    [SerializeField] GameObject Attack;
    public Rigidbody2D rb;
    private bool Dir = true;
    private float horizontal;
    [SerializeField] private GameObject player;
    public LayerMask layerMask;
    [SerializeField] private bool hasLoS = false;
    [SerializeField] Vector2 PlayerDir;
    private bool IsLeft = true;
    private bool IsRight = true;
    [SerializeField] GameObject hitPlayer;
    public bool AttackEnable = false;
    public bool MovementLock = false;
    public bool Attacking = false;
    
    void Start()
    {
        Attack.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    RaycastHit2D LoS = Physics2D.Raycast(transform.position, PlayerDir, 100f, ~layerMask);
    if(LoS.collider != null){
        hasLoS = LoS.collider.CompareTag("Player");

        if(hasLoS){
            if(PlayerDir.x < 0 && !MovementLock){           
                MoveLeft();
            } else if(PlayerDir.x > 0 && !MovementLock ){
                MoveRight();
            }
            if(LoS.distance < 1 && !MovementLock){
                LockMovement(5f);
                rb.velocity = new Vector2(-PlayerDir.x * 2, rb.velocity.y);
                
            }
                
        
            Debug.DrawRay(transform.position, player.transform.position - transform.position);
        }
    }
            SpriteFlip();
      if(AttackEnable){
        Attack.SetActive(true);
        StartCoroutine("LockMovement", 1f);
      } else {
        Attack.SetActive(false);
      }
    }
    void MoveRight(){
        //yield return new WaitForSeconds(1.5f);
        if(!MovementLock){
        rb.velocity = new Vector2(2, rb.velocity.y);
        IsLeft = false;
        IsRight = true;
        }   
    }
    void MoveLeft(){
        if(!MovementLock){
        //yield return new WaitForSeconds(1.5f);
        rb.velocity = new Vector2(-2, rb.velocity.y);
        IsLeft = true;
        IsRight = false;
        }
    }
    public IEnumerator LockMovement(float time){
        print("movement locked");
        MovementLock = true;
        rb.velocity = new Vector2(0, 0);    
        yield return new WaitForSeconds(time);
        MovementLock = false;
    }
    void FixedUpdate(){
        PlayerDir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        PlayerDir = PlayerDir.normalized;
    }
    private void SpriteFlip(){
        if (Dir && rb.velocity.x < 0f && !Attacking ||  !Dir && rb.velocity.x > 0f && !Attacking){
            Dir = !Dir;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            Attack.SetActive(false);
            StartCoroutine("LockMovement", 1f);
        }
        if (Dir && rb.velocity.x < 0f ||  !Dir && rb.velocity.x > 0f ){
            LockMovement(1f);
        }
    }
}