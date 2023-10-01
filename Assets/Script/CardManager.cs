using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

[DefaultExecutionOrder(0)]
public class CardManager : MonoBehaviour
{
    public Transform cardSpawnPoint1, cardSpawnPoint2, cardSpawnPoint3;  // 三张卡牌的生成点
    public GameObject cardPrefab1; 
    public GameObject cardPrefab2; 
    public GameObject cardPrefab3;  // 卡牌的预制件
    public CardDatabase cardDatabase;  // 之前创建的卡牌数据库

    private int day;

  private IEnumerator Start()
{
    while (CardDatabase.IsDataLoaded == false)
    {
        yield return null;
    }
    day = GameManager.Instance.currentDay;
    LoadCardsForDay(day);
    CardDatabase.IsDataLoaded = false;
}

    void LoadCardsForDay(int day)
    {
        
        int card1ID = cardDatabase.GetDailyCardID(0);
        int card2ID = cardDatabase.GetDailyCardID(1);
        int card3ID = cardDatabase.GetDailyCardID(2);

        InstantiateCard(card1ID, cardSpawnPoint1, cardPrefab1);
        Debug.Log("loadcard1");
        InstantiateCard(card2ID, cardSpawnPoint2, cardPrefab2);
        Debug.Log("loadcard2");
        InstantiateCard(card3ID, cardSpawnPoint3, cardPrefab3);
        Debug.Log("loadcard3");
    }

    void InstantiateCard(int cardID, Transform spawnPoint, GameObject cardPrefab)
    {
        Card cardData = cardDatabase.GetCardByID(cardID);
        if (cardData != null)
        {
            GameObject cardObj = Instantiate(cardPrefab, spawnPoint.position, Quaternion.identity);
            CardDisplay display = cardObj.GetComponent<CardDisplay>();
            display.DisplayCard(cardData);
        }
        else
        {
            Debug.LogError("Card ID " + cardID + " not found in database.");
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
