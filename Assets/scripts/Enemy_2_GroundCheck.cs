using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2_GroundCheck : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    

    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("ground")){
        Enemy.GetComponent<Enemy_2>().rb.velocity = new Vector2(0,0);
    }
    }
}
