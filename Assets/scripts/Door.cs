using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public string scene;
    public bool locked;
    public bool Exit;
    public Vector2 playerPos;
    public GameObject gameManager;
    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(Input.GetKeyDown(KeyCode.E) && !locked){
                gameManager.GetComponent<GameManager>().PlayerPos = playerPos;
                gameManager.GetComponent<GameManager>().SceneChange = true;
                SceneManager.LoadScene(scene);
                gameManager.GetComponent<GameManager>().PlayerPos = playerPos;
                gameManager.GetComponent<GameManager>().SceneChange = true;
                print("Nani!?");
            }
            if(Exit){
                gameManager.GetComponent<GameManager>().PlayerPos = playerPos;
                gameManager.GetComponent<GameManager>().SceneChange = true;
                SceneManager.LoadScene(scene);
                gameManager.GetComponent<GameManager>().PlayerPos = playerPos;
                gameManager.GetComponent<GameManager>().SceneChange = true;
            }
        }
    }
}
