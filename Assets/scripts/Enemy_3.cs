    using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    private Vector2 PlayerDir;
    [SerializeField] GameObject player;
    [SerializeField] LayerMask layerMask;
    private bool hasLoS;
    [SerializeField] private float PlayerDistanceX;
    [SerializeField] private float PlayerDistanceY;
    private Rigidbody2D rb;
    public GameObject bullet;
    private GameObject bulletClone;
    public Transform shootPoint;
    private bool isShooting = false;
    private Quaternion playerRotation;
    private bool Dir = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        PlayerDir = PlayerDir.normalized;
        RaycastHit2D LoS = Physics2D.Raycast(transform.position, PlayerDir, 100f, ~layerMask);
        if(LoS.collider != null){
            hasLoS = LoS.collider.CompareTag("Player");
            if(hasLoS){
                print("HasLoS");            
                PlayerDistanceX = player.transform.position.x - transform.position.x;
                PlayerDistanceY = player.transform.position.y - transform.position.y;
                PlayerDistanceX = PlayerDistanceX * PlayerDistanceX / 2;
                PlayerDistanceY = PlayerDistanceY * PlayerDistanceY / 2;
                if(PlayerDistanceX < 5){
                    rb.velocity = new Vector2(-PlayerDir.x, rb.velocity.y);
                }
                if (PlayerDistanceX > 10){
                    rb.velocity = new Vector2(PlayerDir.x, rb.velocity.y);
                }
                if (PlayerDistanceY > 5){
                    rb.velocity = new Vector2(rb.velocity.x, PlayerDir.y);
                }
                if (PlayerDistanceY < 10){
                    rb.velocity = new Vector2(rb.velocity.x, -PlayerDir.y);
                }


            StartCoroutine("Shoot");
            }
        }

    }
    IEnumerator Shoot(){
        if(!isShooting){
            Vector2 targetDirection = player.transform.position- transform.position;
            float angle = Mathf.Atan2(-targetDirection.y, -targetDirection.x) * Mathf.Rad2Deg - 90;    
            playerRotation = Quaternion.Euler(new Vector3(0, 0, angle));



            isShooting = true;
        yield return new WaitForSeconds(5f);
        bulletClone = Instantiate(bullet, shootPoint.position, playerRotation);
        print("TestTest12 ");
        isShooting = false;
         
        }

    }
    private void SpriteFlip(){
        if (Dir && rb.velocity.x < 0f   ||  !Dir && rb.velocity.x > 0f  ){
            Dir = !Dir;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            
        }
        
    }
}
