using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text pressureText;  // ��ק���Pressure UI Text���������
    public TMP_Text healthText;    // ��ק���Health UI Text���������
    public TMP_Text timeText;    // ��ק���Time UI Text���������
    public Slider timeSlider;    // ��ק���Time UI Slider���������
    public TMP_Text satisfactionText;    // ��ק���Satisfaction UI Text���������
    public TMP_Text performanceText;    // ��ק���Performance UI Text���������
    
    int maxTime = 12;



    // ��������һ���������Ի�ȡ��ǰ��pressure��healthֵ
    private int GetPressure()
    {
        // ���ص�ǰ��pressureֵ
        return GameManager.Instance.pressure;
    }

    private int GetHealth()
    {
        // ���ص�ǰ��healthֵ
        return GameManager.Instance.health;
    }

    private int GetTime()
    {
        // ���ص�ǰ��timeֵ
        return GameManager.Instance.time;
    }   

    private int GetSatisfaction()
    {
        // ���ص�ǰ��satisfactionֵ
        return GameManager.Instance.satisfaction;
    }       

    private int GetPerformance()
    {
        // ���ص�ǰ��performanceֵ
        return GameManager.Instance.performance;
    }   

    // Update is called once per frame
    void Update()
    {
        pressureText.text = "Pressure: " + GetPressure().ToString();
        healthText.text = "Health: " + GetHealth().ToString();
        timeText.text = "Time: " + GetTime().ToString();
        satisfactionText.text = "Satisfaction: " + GetSatisfaction().ToString();
        performanceText.text = "Performance: " + GetPerformance().ToString();
        timeSlider.value = GetTime() / maxTime;

    }
}

