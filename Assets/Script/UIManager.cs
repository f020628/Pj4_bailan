using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text pressureText;  // 拖拽你的Pressure UI Text组件到这里
    public TMP_Text healthText;    // 拖拽你的Health UI Text组件到这里
    public TMP_Text timeText;    // 拖拽你的Time UI Text组件到这里
    public Slider timeSlider;    // 拖拽你的Time UI Slider组件到这里
    public TMP_Text satisfactionText;    // 拖拽你的Satisfaction UI Text组件到这里
    public TMP_Text performanceText;    // 拖拽你的Performance UI Text组件到这里
    
    int maxTime = 12;



    // 假设你有一个方法可以获取当前的pressure和health值
    private int GetPressure()
    {
        // 返回当前的pressure值
        return GameManager.Instance.pressure;
    }

    private int GetHealth()
    {
        // 返回当前的health值
        return GameManager.Instance.health;
    }

    private int GetTime()
    {
        // 返回当前的time值
        return GameManager.Instance.time;
    }   

    private int GetSatisfaction()
    {
        // 返回当前的satisfaction值
        return GameManager.Instance.satisfaction;
    }       

    private int GetPerformance()
    {
        // 返回当前的performance值
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

