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
    public static CardManager Instance;

    private int day;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
       // Debug.Log("loadcard1");
        InstantiateCard(card2ID, cardSpawnPoint2, cardPrefab2);
        //Debug.Log("loadcard2");
        InstantiateCard(card3ID, cardSpawnPoint3, cardPrefab3);
       // Debug.Log("loadcard3");
    }

    void InstantiateCard(int cardID, Transform spawnPoint, GameObject cardPrefab)
    {

        Debug.Assert(cardDatabase != null, "CardDatabase is null");
        Debug.Assert(spawnPoint != null, "SpawnPoint is null");
        Debug.Assert(cardPrefab != null, "CardPrefab is null");
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

   

    public void ReplaceCard(int newCardId, GameObject oldCardObject)
{
    
    // Determine which spawn point and prefab to use based on the old card object
    Transform spawnPoint = DetermineSpawnPoint(oldCardObject);
    GameObject cardPrefab = DetermineCardPrefab(oldCardObject);
    
    // Destroy the old card
    Destroy(oldCardObject);

    // Instantiate the new card
    if (newCardId != -1 ) // -1 means no card
    {
        InstantiateCard(newCardId, spawnPoint, cardPrefab);
    }
    
}

    public Transform DetermineSpawnPoint(GameObject oldCardObject)
{
    // 你可以根据oldCardObject的标签或其他属性来确定生成点
    if (oldCardObject.tag == "Card1")
    {
        return cardSpawnPoint1;
    }
    else if (oldCardObject.tag == "Card2")
    {
        return cardSpawnPoint2;
    }
    else if (oldCardObject.tag == "Card3")
    {
        return cardSpawnPoint3;
    }
    else
    {
        // 默认生成点或错误处理
        return null;
    }
}
    public GameObject DetermineCardPrefab(GameObject oldCardObject)
    {    
    // 你可以根据oldCardObject的标签或其他属性来确定预制件
    if (oldCardObject.tag == "Card1")
    {
        return cardPrefab1;
    }
    else if (oldCardObject.tag == "Card2")
    {
        return cardPrefab2;
    }
    else if (oldCardObject.tag == "Card3")
    {
        return cardPrefab3;
    }
    else
    {
        // 默认预制件或错误处理
        return null;
    }
}


}
