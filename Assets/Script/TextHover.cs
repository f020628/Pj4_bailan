using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverPanel;  // Reference to the UI Panel that will show the enlarged text
    public TMP_Text hoverText;  // Reference to the TMP_Text component inside the hoverPanel

    private TMP_Text originalText;  // Reference to the original TMP_Text component

    private void Start()
    {
        originalText = GetComponent<TMP_Text>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverPanel.SetActive(true);  // Show the hoverPanel
        hoverText.text = originalText.text;  // Set the hoverText to the original text
        hoverText.fontSize = originalText.fontSize * 1.5f;  // Increase the font size
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverPanel.SetActive(false);  // Hide the hoverPanel
    }
}
