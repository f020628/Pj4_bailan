using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;


[DefaultExecutionOrder(0)]
public class CardManager : MonoBehaviour
{
    public Transform cardSpawnPoint1, cardSpawnPoint2, cardSpawnPoint3;  // ���ſ��Ƶ����ɵ�
    public GameObject cardPrefab1; 
    public GameObject cardPrefab2; 
    public GameObject cardPrefab3;  // ���Ƶ�Ԥ�Ƽ�
    public CardDatabase cardDatabase;  // ֮ǰ�����Ŀ������ݿ�
    public static CardManager Instance;
    public GameObject endOfDayPanel;  // ��ק���EndOfDayPanel������
    public TMP_Text endOfDayPanelText;

    private int day;

    private float GetTime()
    {
        // ���ص�ǰ��timeֵ
        return GameManager.Instance.time;
    }   
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

        endOfDayPanel.SetActive(false);
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
        StartCoroutine(StartNewDayCoroutine());
    }

   IEnumerator StartNewDayCoroutine()
    {

        string endOfDayText;

        if ( GetTime() < 4)
        {
            endOfDayText = "You don't seem very eager to keep working, I suppose.";
            GameManager.Instance.UpdateStatus(0, -5, +5, -10, -5);
        }
        else if (GetTime() >= 4 && GetTime() < 8)
        {
            endOfDayText = "You got off work too early today.";
            GameManager.Instance.UpdateStatus(0, -3, +3, -5, -3);
        }
        else if (GetTime() == 8)
        {
            endOfDayText = "You got off work early today.";
            GameManager.Instance.UpdateStatus(0, 0, 0, -2, 0);
        }
        else if (GetTime() > 8 && GetTime() < 12)
        {
            endOfDayText = "You worked reasonable hours today.";
            GameManager.Instance.UpdateStatus(0, 1, 0, -1, 1);
        }
        else
        {
            endOfDayText = "You're a good worker.";
            GameManager.Instance.UpdateStatus(0, 3, -2, 2, 2);
        }

        endOfDayPanelText.text = endOfDayText;

        endOfDayPanel.SetActive(true);

        // �ȴ�5��
        yield return new WaitForSeconds(5f);

        // ������һ��
        GameManager.Instance.currentDay++;

        // ˢ�������������߽�����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        // �������Ҫ���¼��س�����ֱ�Ӽ����¿���
        // LoadCardsForDay(GameManager.Instance.currentDay);
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
    // ����Ը���oldCardObject�ı�ǩ������������ȷ�����ɵ�
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
        // Ĭ�����ɵ�������
        return null;
    }
}
    public GameObject DetermineCardPrefab(GameObject oldCardObject)
    {    
    // ����Ը���oldCardObject�ı�ǩ������������ȷ��Ԥ�Ƽ�
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
        // Ĭ��Ԥ�Ƽ��������
        return null;
    }
}


}
