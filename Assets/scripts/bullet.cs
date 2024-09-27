using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
public Rigidbody2D rb;
public GameObject player;
void Start(){
    rb = GetComponent<Rigidbody2D>();
    player = GameObject.FindWithTag("Player");
    rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
    
}

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") || other.CompareTag("ground")){
        Destroy(this.gameObject);
        }
    }
}
