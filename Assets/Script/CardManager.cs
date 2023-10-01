using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CardManager : MonoBehaviour
{
    public Transform cardSpawnPoint1, cardSpawnPoint2, cardSpawnPoint3;  // 三张卡牌的生成点
    public GameObject cardPrefab;  // 卡牌的预制件
    public CardDatabase cardDatabase;  // 之前创建的卡牌数据库

    private int day;

    private void Start()
    {
        day = GameManager.Instance.currentDay;
        LoadCardsForDay(day);
    }

    void LoadCardsForDay(int day)
    {
        // 假设每天的三张卡都是连续的，第一天是012，第二天是345，依此类推
        int card1ID = day * 3 + 1;
        int card2ID = card1ID + 1;
        int card3ID = card2ID + 1;

        InstantiateCard(card1ID, cardSpawnPoint1);
        InstantiateCard(card2ID, cardSpawnPoint2);
        InstantiateCard(card3ID, cardSpawnPoint3);
    }

    void InstantiateCard(int cardID, Transform spawnPoint)
    {
        Card cardData = cardDatabase.GetCardByID(cardID);
        if (cardData != null)
        {
            GameObject cardObj = Instantiate(cardPrefab, spawnPoint.position, Quaternion.identity);
            CardDisplay display = cardObj.GetComponent<CardDisplay>();
            //display.Setup(cardData);
        }
    }
    public void StartNewDay()
    {
        GameManager.Instance.currentDay++;
        // 如果需要刷新整个场景：
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        // 如果不需要重新加载场景，直接加载新卡：
        //LoadCardsForDay(GameManager.Instance.currentDay);
    }
}
