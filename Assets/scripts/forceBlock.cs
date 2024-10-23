using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class forceBlock : MonoBehaviour
{
    private GameObject Player;
    public float force;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            Player.GetComponent<PlayerController>().rb.velocity = new Vector2(Player.GetComponent<PlayerController>().rb.velocity.x, force);
        }
    }
    
    
}
