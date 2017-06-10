using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    public System.Action<CardData> OnSelect;

    public Text title;
    public Text instructions;
    public Text flavor;
    public bool isSub;
    public bool isClickable;

    public CardData cardData { get; private set; }
    public bool isChosen { get; private set; }

    public void SetCardView(CardData card, bool isSub, bool isClickable)
    {
        this.isClickable = isClickable;
        this.isSub = isSub;
        title.text = card.title;
        instructions.text = this.isSub ? card.subInstructions : card.domInstructions;
        flavor.text = card.flavor;
        cardData = card;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Click();

        if (OnSelect != null)
            OnSelect(cardData);
    }

    public void Click()
    {
        if (!isClickable)
            return;

        if (isChosen)
        {
            transform.DOMoveY(transform.position.y - 25, .2f);
            isChosen = false;
        }
        else
        {
            transform.DOMoveY(transform.position.y + 25, .2f);
            isChosen = true;
        }
    }

    public void SubmitMe(int toWhere)
    {
        switch (toWhere)
        {
            case 0:
                Deck.SubmitBondage(cardData);
                break;

            case 1:
                Deck.SubmitTouch(cardData);
                break;

            case 2:
                Deck.SubmitAction(cardData);
                break;
        }
    }
}
