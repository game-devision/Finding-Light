using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject PauseMenu;
    bool IsPaused = false;
    public GameObject Player;
    public GameObject gameManager;

    void Start(){
        PauseMenu.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindWithTag("gameManager");
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(IsPaused){
                Unpause();
            } else {
                PauseGame();
            }
        }
    }
    public void PauseGame(){
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        IsPaused = true;
        Player.GetComponent<PlayerController>().enabled = false;
        
    }
    public void Unpause(){
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        IsPaused = false;
        Player.GetComponent<PlayerController>().enabled = true;
    }
    public void Quit(){
        SceneManager.LoadScene("MainMenu");
        Destroy(gameManager);
    }
}
