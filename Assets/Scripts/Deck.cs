using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Deck
{
    public static List<CardData> deckActions { get; private set; }
    public static List<CardData> deckBondages { get; private set; }
    public static List<CardData> deckTouches { get; private set; }

    static Deck()
    {
        deckActions = new List<CardData>();
        deckBondages = new List<CardData>();
        deckTouches = new List<CardData>();
    }

    // SUBMITTING CARDS //
    public static void SubmitAction(CardData card)
    {
        Submit(deckActions, card);
    }

    public static void SubmitBondage(CardData card)
    {
        Submit(deckBondages, card);
    }

    public static void SubmitBondage(List<CardData> cards)
    {
        Submit(deckBondages, cards);
    }

    public static void SubmitTouch(CardData card)
    {
        Submit(deckTouches, card);
    }

    public static void SubmitTouch(List<CardData> cards)
    {
        Submit(deckTouches, cards);
    }

    static void Submit(List<CardData> deck, CardData card)
    {
        deck.Add(card);
    }

    static void Submit(List<CardData> deck, List<CardData> cards)
    {
        deck.AddRange(cards);
    }
}
