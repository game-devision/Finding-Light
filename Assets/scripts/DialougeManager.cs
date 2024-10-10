using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class DialougeManager : MonoBehaviour
{
    public bool IsSpeaking = true;
    private Queue<string> sentences;
    public GameObject Name;                                                
    public GameObject sentencestenence;
    public GameObject DialougeBox;
    public TMP_Text Name2;
    public TMP_Text sentencestenence2;
    GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {

        sentences = new Queue<string>();
        Name2 = Name.GetComponent<TMP_Text>(); 
        sentencestenence2 = sentencestenence.GetComponent<TMP_Text>(); 
        DialougeBox.SetActive(false);
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
    }
    void Update(){
        if(IsSpeaking){
            if(Input.GetMouseButtonDown(1)){
                DisplayNextSentence();
                
            }
        }
    }
    public void StartDialouge(Dialouge dialouge){
        DialougeBox.SetActive(true);
        Debug.Log(dialouge.Name + " Started yapping ");
        Name2.SetText(dialouge.Name);
        sentences.Clear ();
        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Invoke("DisplayNextSentence", 0.1f);
        Time.timeScale = 0f;
        pauseMenu.SetActive(false);

    }
    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        print(sentence);
        sentencestenence2.SetText(sentence);  
    }
    void EndDialouge(){
        DialougeBox.SetActive(false);
        Debug.Log("They stopped yapping");  
        Time.timeScale = 1f;
        pauseMenu.SetActive(true);
    }
}
