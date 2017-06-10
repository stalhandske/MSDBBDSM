using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLibrary : MonoBehaviour {

	void Start ()
    {
        foreach (CardData card in LibraryManager.DrawActions(4))
        {
            Debug.Log(card.title);
            Deck.SubmitAction(card);
        }

        foreach (CardData card in LibraryManager.DrawTouches(2))
        {
            Debug.Log(card.title);
            Deck.SubmitTouch(card);
        }

        foreach (CardData card in LibraryManager.DrawBondages(2))
        {
            Debug.Log(card.title);
            Deck.SubmitBondage(card);
        }

        foreach (CardData card in Deck.deckActions)
        {
            Debug.Log(card.title);
        }

        foreach (CardData card in Deck.deckBondages)
        {
            Debug.Log(card.title);
        }

        foreach (CardData card in Deck.deckTouches)
        {
            Debug.Log(card.title);
        }
    }
}
