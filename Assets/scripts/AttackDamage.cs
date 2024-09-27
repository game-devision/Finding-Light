using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public int damage;
    public bool isPlayer;
    [SerializeField] private GameObject Player;
    [SerializeField] private bool isBullet = false;

    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !isPlayer){
        Player.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
        if(other.CompareTag("Enemy") && isPlayer){
            other.GetComponent<Health>().ChangeHealth(-damage);
            if(!isBullet){
            Player.GetComponent<PlayerController>().ammo += 1;
            }
        }

    }

}
