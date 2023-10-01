using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    //public Image cardImage;
    public TMP_Text cardNameText;
    public TMP_Text cardDescriptionText;

    [System.Serializable]
    public class CardOptionUI
    {
        public TMP_Text optionText;
        public Button optionButton;
        public GameObject optionContainer;  // The container that holds the text and button
    }

    public CardOptionUI[] optionsUI;  // Set this to size 3 in the inspector

    private void Start()
    {
        //DisplayCard();
    }

    public void DisplayCard(Card cardData)
    {
        //cardImage.sprite = cardData.cardImage;
        cardNameText.text = cardData.cardName;
        cardDescriptionText.text = cardData.description;

        for (int i = 0; i < optionsUI.Length; i++)
        {
            if (i < cardData.options.Length)
            {   if(cardData.options[i]!= null){
                    optionsUI[i].optionText.text = cardData.options[i].choiceText;
                    optionsUI[i].optionContainer.SetActive(true); // Show this option
                }
                else{
                    optionsUI[i].optionContainer.SetActive(false);  // Hide this option
                }
                // Optionally, you can add button functionality here:
                // optionsUI[i].optionButton.onClick.AddListener(() => YourFunction(cardData.options[i]));
            }
            else
            {
                optionsUI[i].optionContainer.SetActive(false);  // Hide this option
            }
        }
    }
    /* public void Setup(Card cardData)
{
        cardImage.sprite = cardData.cardImage;
        cardNameText.text = cardData.cardName;
        cardDescriptionText.text = cardData.description;

        for (int i = 0; i < optionsUI.Length; i++)
        {
            if (i < cardData.options.Length)
            {
                optionsUI[i].optionText.text = cardData.options[i].choiceText;
                optionsUI[i].optionContainer.SetActive(true);  // Show this option
                // Optionally, you can add button functionality here:
                // optionsUI[i].optionButton.onClick.AddListener(() => YourFunction(cardData.options[i]));
            }
            else
            {
                optionsUI[i].optionContainer.SetActive(false);  // Hide this option
            }
        }
} */

}



