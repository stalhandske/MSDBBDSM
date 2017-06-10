using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    public Text title;
    public Text instructions;
    public Text flavor;
    public bool isSub;
    public bool isClickable;

    public void SetCardView(CardData card, bool isSub, bool isClickable)
    {
        this.isClickable = isClickable;
        this.isSub = isSub;
        title.text = card.title;
        instructions.text = this.isSub ? card.subInstructions : card.domInstructions;
        flavor.text = card.flavor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClickable)
            return;
    }
}
