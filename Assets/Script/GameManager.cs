using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����ģʽ��ʹ������ű��������κεط�������
    public static GameManager Instance;

    // ��Ϸ״̬���������
    public int currentDay = 0;
    public int health = 100;
    public int pressure = 100;
    public int satisfaction = 100;
    public int performance = 100;

    // ����ʱʹ�õĹؼ���
    private const string DAY_KEY = "CurrentDay";
    private const string HEALTH_KEY = "Health";
    private const string PRESSURE_KEY = "Pressure";
    private const string SATISFACTION_KEY = "Satisfaction";
    private const string PERFORMANCE_KEY = "Performance";

    private void Awake()
    {
        // ȷ��������ֻ��һ��GameManagerʵ��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // �������³���ʱ�����ݻ��������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadGameData();  // ����ʱ���ر��������
    }

    public void EndDayAndLoadNext()
    {
        currentDay++;
        SaveGameData(); // ������Ϸ����
        // ���¼��س����������߼�...
    }

    // ������Ϸ���ݵ�PlayerPrefs
    public void SaveGameData()
    {
        PlayerPrefs.SetInt(DAY_KEY, currentDay);
        PlayerPrefs.SetInt(HEALTH_KEY, health);
        PlayerPrefs.SetInt(SATISFACTION_KEY, satisfaction);
        PlayerPrefs.SetInt(PERFORMANCE_KEY, performance);
    }

    // ��PlayerPrefs������Ϸ����
    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey(DAY_KEY))
        {
            currentDay = PlayerPrefs.GetInt(DAY_KEY);
        }
        if (PlayerPrefs.HasKey(HEALTH_KEY))
        {
            health = PlayerPrefs.GetInt(HEALTH_KEY);
        }
        if (PlayerPrefs.HasKey(SATISFACTION_KEY))
        {
            satisfaction = PlayerPrefs.GetInt(SATISFACTION_KEY);
        }
        if (PlayerPrefs.HasKey(PERFORMANCE_KEY))
        {
            performance = PlayerPrefs.GetInt(PERFORMANCE_KEY);
        }
    }

    // ���ﻹ������������������Ϸ�߼������״̬�ķ���

   
}
