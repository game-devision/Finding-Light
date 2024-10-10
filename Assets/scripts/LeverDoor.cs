using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    public GameObject lever;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (lever.GetComponent<lever>()._on){
            gameObject.SetActive(false);
        }
    }
}
