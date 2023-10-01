using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Game/Card")]
public class Card : ScriptableObject
{
    public new string cardName;
    public string description;
    public Sprite cardImage;
    public int attack;
    public int defense;
    // �������ԣ���ħ��ֵ�����⼼�ܵ�
}

