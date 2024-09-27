using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    [SerializeField] GameObject Player;
    

    void OnTriggerStay2D(Collider2D other)
    {
    if (other.CompareTag("ground")){
        Player.GetComponent<PlayerController>().IsGrounded = true;
    }
    }
    void OnTriggerExit2D(){
        Player.GetComponent<PlayerController>().IsGrounded = false;
    }
}
