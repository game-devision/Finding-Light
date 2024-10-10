using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public bool _on = false;
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Attack")){
            _on = !_on;
            transform.Rotate(0,180, 0);
        }
    }
}