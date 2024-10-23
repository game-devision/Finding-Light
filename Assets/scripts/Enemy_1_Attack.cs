using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_1_Attack : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject player;
    void Start(){
        player = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D other){
        
        if(other.CompareTag("Player")&& player.GetComponent<PlayerController>().isDashing == false){
        Enemy.GetComponent<Enemy_1>().Attacking = true;
        print("triggerEnter");  
        Enemy.GetComponent<Enemy_1>().StartCoroutine("LockMovement", 2f);
        StartCoroutine("Attack");
        }
    }
    IEnumerator Attack(){
        yield return new WaitForSeconds(1f) ;
        Enemy.GetComponent<Enemy_1>().AttackEnable = true;
        yield return new WaitForSeconds(0.5f);
        Enemy.GetComponent<Enemy_1>().AttackEnable = false;
        Enemy.GetComponent<Enemy_1>().Attacking = false; 
    }
}