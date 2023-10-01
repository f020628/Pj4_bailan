using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class CardDatabase : MonoBehaviour
{
    public TextAsset csvFile;  // ָ���㵼���CSV�ļ�������

    public List<Card> cardList = new List<Card>();

    public int[] dailyCardIDs;
    public int currentDay = 0;

    void Start()
    {
        
        Addressables.LoadAssetAsync<TextAsset>("CardData.csv").Completed += OnCardDataLoaded;
        dailyCardIDs = new int[15] { 1, 7, 9, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15 };
        List<Card> cardsToday = GetCardsForTheDay();
        //Debug.Log(cardList[0].cardName);
    }

    void OnCardDataLoaded(AsyncOperationHandle<TextAsset> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            csvFile = obj.Result;
            ParseCSV();
        }
        else
        {
            Debug.LogError("Failed to load CardData.csv");
        }
    }
    void ParseCSV()
    {
        string[] data = csvFile.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length - 1; i++) //��1��ʼ���Ա��������
        {
            string[] row = Regex.Split(data[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");  // ���������ʽ���Դ�������ŵ��ֶ�

            Card cd = ScriptableObject.CreateInstance<Card>();
            cd.cardID = int.Parse(row[0]);
            cd.cardName = row[1];
            //cd.cardImage = Resources.Load<Sprite>(row[2]);  // �����㽫��ƬͼƬ����Resources�ļ�����
            cd.description = row[3];
            // Process options
            for (int j = 0; j < 3; j++)
            {
                int baseIndex = 4 + j * 7;  // Based on the given CSV format, every option has 6 columns
                if(row[baseIndex] != "None")
                {
                    CardOption option = new CardOption
                    {
                        choiceText = row[baseIndex],
                        jumpToId = int.Parse(row[baseIndex + 1]),
                        time = int.Parse(row[baseIndex + 2]),
                        pressure = int.Parse(row[baseIndex + 3]),
                        health = int.Parse(row[baseIndex + 4]),
                        performance = int.Parse(row[baseIndex + 5]),
                        satisfaction = int.Parse(row[baseIndex + 6])
                    };
                    cd.options[j] = option;
                }
                else
                {
                    cd.options[j] = null; // If "None", then the option will be null, you can check this later in the game logic to decide whether to display it or not
                }
            }
            cardList.Add(cd);
        }
    }
    public Card GetCardByID(int id)
    {
        foreach(Card card in cardList)
        {
            if(card.cardID == id)
            {
                return card;
            }
        }
        return null; // ���û���ҵ���ӦID�Ŀ�Ƭ�򷵻�null
    }

    public List<Card> GetCardsForTheDay()
    {
        List<Card> cardsForToday = new List<Card>();

        // ���ݵ�ǰ�����ڣ���ȡ��ƬID
        int cardStartIndex = currentDay * 3;  // ÿ��3�ſ�Ƭ
        for (int i = 0; i < 3; i++)
        {
            if(cardStartIndex + i < dailyCardIDs.Length)
            {
                Card cardToAdd = GetCardByID(dailyCardIDs[cardStartIndex + i]);
                if (cardToAdd != null)
                {
                    cardsForToday.Add(cardToAdd);
                    Debug.Log("Card added: " + cardToAdd.cardName);
                }
            }   
            Debug.Log(i);
            
        }

        return cardsForToday;
    }

}
