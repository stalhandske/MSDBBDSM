using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {



    [Header("References")]
    public Transform cardParent;

    [Header("Prefabs")]
    public GameObject cardPrefab;
    
	void Start ()
    {
        InstantiateDeck(Deck.deckActions);
        InstantiateDeck(Deck.deckBondages);
        InstantiateDeck(Deck.deckTouches);
    }

    void InstantiateDeck(List<CardData> deck)
    {
        Debug.Log(deck.Count);
        foreach(CardData card in deck)
        {
            GameObject cardGO = Instantiate(cardPrefab, cardParent);
            cardGO.GetComponent<CardView>().SetCardView(card);
        }
    }
    
}
