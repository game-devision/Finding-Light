using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class oneSidedPlat : MonoBehaviour
{
    private PlatformEffector2D effector;
   
    void Start()
    {
        
    }
    void Update(){
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            GetComponent<TilemapCollider2D>().enabled = false;
            print("This is already enough, i'll figure out the rest");
        } else {
            GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}
