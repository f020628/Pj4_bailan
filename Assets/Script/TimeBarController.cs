using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    public RectTransform pointerRectTransform;  // ��קָ���RectTransform���������
    public float barLength = 100f;  // UI bar�ĳ���

    // ��������һ����������ȡ��ǰ��timeֵ�����timeֵ
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
