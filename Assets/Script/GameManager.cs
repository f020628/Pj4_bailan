using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 单例模式，使得这个脚本可以在任何地方被访问
    public static GameManager Instance;

    // 游戏状态和玩家属性
    public int currentDay = 0;
    public int health = 100;
    public int pressure = 100;
    public int satisfaction = 100;
    public int performance = 100;
    public int time = 0;

    // 保存时使用的关键字
    private const string DAY_KEY = "CurrentDay";
    private const string HEALTH_KEY = "Health";
    private const string PRESSURE_KEY = "Pressure";
    private const string SATISFACTION_KEY = "Satisfaction";
    private const string PERFORMANCE_KEY = "Performance";
    private const string TIME_KEY = "Time";

    private void Awake()
    {
        // 确保场景中只有一个GameManager实例
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 当加载新场景时，不摧毁这个对象
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadGameData();  // 启动时加载保存的数据
    }

    public void EndDayAndLoadNext()
    {
        currentDay++;
        SaveGameData(); // 保存游戏数据
        // 重新加载场景或其他逻辑...
    }

    // 保存游戏数据到PlayerPrefs
    public void SaveGameData()
    {
        PlayerPrefs.SetInt(DAY_KEY, currentDay);
        PlayerPrefs.SetInt(HEALTH_KEY, health);
        PlayerPrefs.SetInt(SATISFACTION_KEY, satisfaction);
        PlayerPrefs.SetInt(PERFORMANCE_KEY, performance);
        PlayerPrefs.SetInt(TIME_KEY, time);
        PlayerPrefs.SetInt(PRESSURE_KEY, pressure);
    }

    // 从PlayerPrefs加载游戏数据
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
        if (PlayerPrefs.HasKey(TIME_KEY))
        {
            time = PlayerPrefs.GetInt(TIME_KEY);
        }
        if (PlayerPrefs.HasKey(PRESSURE_KEY))
        {
            pressure = PlayerPrefs.GetInt(PRESSURE_KEY);
        }
    }
    
    // 这里还可以添加其他管理游戏逻辑和玩家状态的方法
    public void UpdateStatus(int time, int pressure, int health, int performance, int satisfaction)
    {
        this.time += time;
        this.pressure += pressure;
        this.health += health;
        this.performance += performance;
        this.satisfaction += satisfaction;
    }
   
}

