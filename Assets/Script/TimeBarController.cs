using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    public RectTransform pointerRectTransform;  // 拖拽指针的RectTransform组件到这里
    public float barLength = 100f;  // UI bar的长度

    // 假设你有一个方法来获取当前的time值和最大time值
    private float GetCurrentTime()
    {
        return GameManager.Instance.time;
    }

    void Update()
    {
        float currentTime = GetCurrentTime();
        float maxTime = 12;
        float newPosition = (currentTime / maxTime) * barLength;
        pointerRectTransform.anchoredPosition = new Vector2(newPosition, 0);
    }
}
