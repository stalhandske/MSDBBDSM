﻿using System.Collections;
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

    [Header("References")]
    public Transform cardParent;

    [Header("Prefabs")]
    public GameObject cardPrefab;
    
    void Start()
    {

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
        for (int i = 0; i < cardParent.childCount; i++)
        {
            Destroy(cardParent.GetChild(i).gameObject);
        }
    }

    void InstantiateDeck(List<CardData> deck)
    {
        // Debug.Log(deck.Count);
        foreach (CardData card in deck)
        {
            GameObject cardGO = Instantiate(cardPrefab, cardParent);
            cardGO.GetComponent<CardView>().SetCardView(card, isSub, isClickable);
        }
    }
    
}