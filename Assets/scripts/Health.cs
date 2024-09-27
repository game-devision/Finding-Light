using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount){
            
            if (currentHealth > 0)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    void Update()
    {
        if (currentHealth <= 0){
            print("YOU WERE SLAIN");
            if(this.CompareTag("Enemy")){
                Destroy(this.gameObject);
            }
        }
        }
}