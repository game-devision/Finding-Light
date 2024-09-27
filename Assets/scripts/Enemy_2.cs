using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 PlayerDir;
    public GameObject player;
    public LayerMask layerMask;
    private bool hasLoS;  
    private float jumpDistance;

    private float jumpHight;
    private bool isJumping = false;
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
                StartCoroutine("Jump");
                print("HasLos");    
            }
        }
    }
    IEnumerator Jump(){
        if(!isJumping){
        isJumping = true;
        jumpHight = Random.Range(5,10);
        jumpDistance = Random.Range(5, 10);
        rb.velocity = new Vector2(PlayerDir.x * jumpDistance, jumpHight);
        yield return new WaitForSeconds(5f);
        isJumping = false;
        }
    }
}

