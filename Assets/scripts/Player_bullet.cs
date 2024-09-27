using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    private float speed = 15;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        print(player.transform.position);
        print(transform.position);
        rb.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    rb.velocity = transform.right * speed;

    }
    void OnTriggerEnter2D(){
        if(!gameObject.CompareTag("Player")){
            Destroy(GetComponent<SpriteRenderer>());
            Invoke("Delete", 0.1f);
        }
    }
    void Delete(){
        Destroy(this.gameObject);
    }

}
