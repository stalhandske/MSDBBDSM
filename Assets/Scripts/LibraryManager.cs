using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LibraryManager
{
    static List<CardData> _libraryActions;
    static List<CardData> _libraryBondages;
    static List<CardData> _libraryTouches;

    static LibraryManager()
    {
        LibraryData libraryData = CardLoaderSaver.LoadLibraryFromResources();
        _libraryActions = libraryData.actionCards;
        _libraryBondages = libraryData.bondageCards;
        _libraryTouches = libraryData.touchCards;
    }

    public static List<CardData> DrawActions(int count)
    {
        return DrawCards(_libraryActions, count);
    }

    public static List<CardData> DrawBondages(int count)
    {
        return DrawCards(_libraryBondages, count);
    }

    public static List<CardData> DrawTouches(int count)
    {
        return DrawCards(_libraryTouches, count);
    }

    static List<CardData> DrawCards(List<CardData> library, int count)
    {
        GrabBag grabBag = new GrabBag(library.Count);
        List<CardData> draw = new List<CardData>();
        for (int i = 0; i < count; i++)
        {
            draw.Add(library[grabBag.Grab()]);
        }

        return draw;
    }
}
