using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject Player;

    public CinemachineVirtualCamera camShake;
    private float ShakeIntesity = 2f;
    private float shakeTime = 0.2f;
    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
        
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void ShakeCamera(){
        CinemachineBasicMultiChannelPerlin _cbmcp = camShake.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntesity;
        timer = shakeTime;
    }
    void StopShake(){
        CinemachineBasicMultiChannelPerlin _cbmcp = camShake.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }
    public void ChangeHealth(int amount){
            if(!Player.GetComponent<PlayerController>().isDashing){
            if (currentHealth > 0)
            {
                currentHealth += amount;
                
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
            }
        }
        if (amount < 0){
            ShakeCamera();
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
        if (timer > 0){
            timer -= Time.deltaTime;
        }
        if (timer <= 0){
            StopShake();
        }
        }
}
