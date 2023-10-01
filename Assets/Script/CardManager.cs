using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CardManager : MonoBehaviour
{
    public Transform cardSpawnPoint1, cardSpawnPoint2, cardSpawnPoint3;  // ���ſ��Ƶ����ɵ�
    public GameObject cardPrefab;  // ���Ƶ�Ԥ�Ƽ�
    public CardDatabase cardDatabase;  // ֮ǰ�����Ŀ������ݿ�

    private int day;

    private void Start()
    {
        day = GameManager.Instance.currentDay;
        LoadCardsForDay(day);
    }

    void LoadCardsForDay(int day)
    {
        // ����ÿ������ſ����������ģ���һ����012���ڶ�����345����������
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
        // �����Ҫˢ������������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        // �������Ҫ���¼��س�����ֱ�Ӽ����¿���
        //LoadCardsForDay(GameManager.Instance.currentDay);
    }
}
