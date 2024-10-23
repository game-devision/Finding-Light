using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    GameObject _player;
    void Start(){
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
                _player.GetComponent<PlayerController>().rb.velocity = new Vector2(0, 5);
                print("Nah id lose");
            }
        }
    }
}
