        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NPC : MonoBehaviour
{
    public UnityEvent Interact;
    public Dialouge dialouge;
    public GameObject DialougeManager;
    

    
    public void TriggerDialouge(){
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player"))
        if(Input.GetKeyDown(KeyCode.E)){
            DialougeManager.GetComponent<DialougeManager>().StartDialouge(dialouge);
            print("IsItCake?");
        }
        
    }
}
