using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class CardOption
{
    public string choiceText;
    public int jumpToId;  // Jump to this card ID when this option is selected
    public int time;
    public int pressure;
    public int health;
    public int performance;
    public int satisfaction;
    // 其他属性，例如选项的效果、消耗等
}
[CreateAssetMenu(fileName = "New Card", menuName = "Card Game/Card")]
public class Card : ScriptableObject
{
    public int cardID;
    public string cardName;
    public string description;
    //public Sprite cardImage;
    public  CardOption[] options = new CardOption[3];
}

