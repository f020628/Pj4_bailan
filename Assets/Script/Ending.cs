using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text EndText;    // 拖拽你的Health UI Text组件到这里

    void Start()
    {
    int health = GameManager.Instance.health;
    int pressure = GameManager.Instance.pressure;
    int satisfaction = GameManager.Instance.satisfaction;
    int performance = GameManager.Instance.performance;
    GameManager.Instance.resetAll(); 
    //Debug.Log("day " + GameManager.Instance.currentDay);   
    showEnding(health,pressure,performance,satisfaction);

    }

   void showEnding(int health,int pressure,int performance ,int satisfaction)
   {
        string displayText = "Welldone!";

        if (pressure == 100)
        {
            if(health==0)
            {
                displayText += "You suicide";
            }
            else if (performance <50)
            {
                displayText += "You got fired";
            }
            else if (satisfaction <50)
            {
                displayText += "You quit the job";
            }
            else
            {
                 displayText += "You are tired";
            }
        }
        if (health == 0)
        {
            if(pressure==100)
            {
                displayText += "You suicide";
            }
            else if (performance <50)
            {
                displayText += "You got fired";
            }
            else if (satisfaction <50)
            {
                displayText += "You quit the job";
            }
            else
            {
                 displayText += "You got sick";
            }
        }
        if (performance == 0)
        {
             displayText += "You got fired";
        }
        if (satisfaction == 0)
        {
            displayText += "You quit the job";
        }
        
        EndText.text = displayText;
   }
   

   
}
