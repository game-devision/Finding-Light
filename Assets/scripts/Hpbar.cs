using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] HpArray;
    public Image HpSprite;
    public GameObject player;
    private float HPPercent;
    private float spriteNumber;
    // Update is called once per frame
    void Update()
    {
        HPPercent = player.GetComponent<PlayerHealth>().currentHealth / player.GetComponent<PlayerHealth>().maxHealth * 100;
        spriteNumber = HPPercent / 4;
        if(HPPercent == 100){
            HpSprite.sprite = HpArray[25];
      } else if (HPPercent > 0) {
        HpSprite.sprite = HpArray[(int)spriteNumber];
        
      } else {
        HpSprite.sprite = HpArray[0];
      }
      
      /* else if(HPPercent > 96){
            HpSprite.sprite = HpArray[1];
        } else if(HPPercent > 92){
            HpSprite.sprite = HpArray[2];
        }   else if(HPPercent > 88){
            HpSprite.sprite = HpArray[3];
        }else if(HPPercent > 84){
            HpSprite.sprite = HpArray[4];
        } else if(HPPercent > 80){
            HpSprite.sprite = HpArray[5];
        } else if(HPPercent > 76){
            HpSprite.sprite = HpArray[6];
        }else if(HPPercent > 72){
            HpSprite.sprite = HpArray[7];
        } else if(HPPercent > 68){
            HpSprite.sprite = HpArray[8];
        } else if(HPPercent > 64){
            HpSprite.sprite = HpArray[9];
        } else if(HPPercent > 60){
            HpSprite.sprite = HpArray[10];
        } else if(HPPercent > 56){
            HpSprite.sprite = HpArray[11];
        } else if(HPPercent > 52){
            HpSprite.sprite = HpArray[12];
        } else if(HPPercent > 48){
            HpSprite.sprite = HpArray[13];
        }
        */
            }
}
