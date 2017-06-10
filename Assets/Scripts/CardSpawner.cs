using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [Header("Draw from deck or library")]
    public bool fromDeck;

    [Header("Draw count if from library")]
    public int drawCount;

    [Header("Choose types of cards")]
    public bool fromTouches;
    public bool fromBondages;
    public bool fromActions;

    [Header("Card prefab properties")]
    public bool isSub;
    public bool isClickable;
    public bool exclusiveSelection;

    [Header("References")]
    public Transform cardParent;

    [Header("Prefabs")]
    public GameObject cardPrefab;

    List<CardView> _spawnedCards;
    int currentWhere;

    void Awake()
    {
        _spawnedCards = new List<CardView>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ClearCards();
            Spawn(0, false, 3);
        }
    }

    public void Spawn()
    {
        if (fromDeck)
        {
            if (fromBondages)
                InstantiateDeck(Deck.deckBondages);
            if (fromTouches)
                InstantiateDeck(Deck.deckTouches);
            if (fromActions)
                InstantiateDeck(Deck.deckActions);
        }
        else
        {
            if (fromBondages)
                InstantiateDeck(LibraryManager.DrawBondages(drawCount));
            if (fromTouches)
                InstantiateDeck(LibraryManager.DrawTouches(drawCount));
            if (fromActions)
                InstantiateDeck(LibraryManager.DrawActions(drawCount));
        }
    }

    // 0 - bondage
    // 1 - touches
    // 2 - actions
    public void Spawn(int fromWhere, bool deck, int count)
    {
        currentWhere = fromWhere;
        switch (fromWhere)
        {
            case 0:
                {
                    if (deck)
                        InstantiateDeck(Deck.deckBondages);
                    else
                        InstantiateDeck(LibraryManager.DrawBondages(count));
                }
                break;

            case 1:
                {
                    if (deck)
                        InstantiateDeck(Deck.deckTouches);
                    else
                        InstantiateDeck(LibraryManager.DrawTouches(count));
                }
                break;

            case 2:
                {
                    if (deck)
                        InstantiateDeck(Deck.deckActions);
                    else
                        InstantiateDeck(LibraryManager.DrawActions(count));
                }
                break;
        }
    }
        
    public void ClearCards()
    {
        for (int i = 0; i < _spawnedCards.Count; i++)
        {
            _spawnedCards[i].SubmitMe(currentWhere);
            Destroy(_spawnedCards[i].gameObject);
        }
        _spawnedCards.Clear();
    }

    void InstantiateDeck(List<CardData> deck)
    {
        // Debug.Log(deck.Count);
        foreach (CardData card in deck)
        {
            GameObject cardGO = Instantiate(cardPrefab, cardParent);
            CardView cardView = cardGO.GetComponent<CardView>();
            cardView.SetCardView(card, isSub, isClickable);
            _spawnedCards.Add(cardView);
            cardView.OnSelect += HandleSelect;
        }
    }
    
    public void HandleSelect(CardData cardData)
    {
        if (exclusiveSelection)
        {
            foreach (CardView cardView in _spawnedCards)
            {
                if (cardView.cardData!=cardData && cardView.isChosen)
                {
                    cardView.Click();
                }
            }
        }
    }
}
