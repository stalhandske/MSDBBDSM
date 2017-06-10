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

    RectTransform _childRectTransform;

    IEnumerator Start()
    {
        _childRectTransform = transform.GetChild(0).GetComponent<RectTransform>();

        transform.eulerAngles = new Vector3(0, 180, 0);
        Vector2 startMax = _childRectTransform.anchorMax;
        Vector2 startMin = _childRectTransform.anchorMin;
        Vector2 newMax = startMax;
        Vector2 newMin = startMin;
        newMax.y -= 1.5f;
        newMin.y -= 1.5f;
        _childRectTransform.anchorMax = newMax;
        _childRectTransform.anchorMin = newMin;

        yield return new WaitForSeconds(Random.Range(0, 0.5f));
        _childRectTransform.DOAnchorMax(startMax, .6f).SetEase(Ease.OutBack);
        _childRectTransform.DOAnchorMin(startMin, .6f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(Random.Range(.0f, .2f));
        transform.DORotate(new Vector3(0, 1, 0), 1f).SetEase(Ease.OutFlash);
        
        //transform.DOPunchScale(Vector3.one * .1f, .2f);
    }

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
        DestroyMe();
    }

    public void DestroyMe()
    {
        StartCoroutine(DestroyMeCr());
    }

    IEnumerator DestroyMeCr()
    {
        //yield return new WaitForSeconds(Random.Range(0, 0.5f));

        transform.DORotate(new Vector3(0, -90, 0), .3f);

        yield return new WaitForSeconds(.3f);

        Destroy(gameObject);
    }
}
