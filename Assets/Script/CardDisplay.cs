using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card; // ÒýÓÃScriptable Object

    public Text nameText;
    public Image artworkImage;
    public Text attackText;
    public Text defenseText;

    private void Start()
    {
        DisplayCard();
    }

    public void DisplayCard()
    {
        nameText.text = card.cardName;
        artworkImage.sprite = card.cardImage;
        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
    }
}

