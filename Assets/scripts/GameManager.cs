using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Vector2 PlayerPos;
    public bool SceneChange;
    public float PlayerHP;
    public float PlayerAmmo;
    public PlayerController playerController;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update(){
        
        if(SceneChange){
        SceneChange = false;    
        print("testoe");
        Invoke("MovePlayer", 0.1f);
        }
    }
    void MovePlayer(){
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = PlayerPos;
    }
    public void exit(){
        Application.Quit();
    }
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
