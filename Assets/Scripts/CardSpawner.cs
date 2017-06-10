using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {

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

    [Header("References")]
    public Transform cardParent;

    [Header("Prefabs")]
    public GameObject cardPrefab;
    
	void Start ()
    {
        if (fromDeck)
        {
            if (fromBondages) InstantiateDeck(Deck.deckBondages);
            if (fromTouches) InstantiateDeck(Deck.deckTouches);
            if (fromActions) InstantiateDeck(Deck.deckActions);
        }
        else
        {
            if (fromBondages) InstantiateDeck(LibraryManager.DrawBondages(drawCount));
            if (fromTouches) InstantiateDeck(LibraryManager.DrawTouches(drawCount));
            if (fromActions) InstantiateDeck(LibraryManager.DrawActions(drawCount));
        }
    }

    void InstantiateDeck(List<CardData> deck)
    {
        Debug.Log(deck.Count);
        foreach(CardData card in deck)
        {
            GameObject cardGO = Instantiate(cardPrefab, cardParent);
            cardGO.GetComponent<CardView>().SetCardView(card,isSub, isClickable);
        }
    }
    
}
