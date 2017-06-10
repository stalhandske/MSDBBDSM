using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLibrary : MonoBehaviour {

	
	void Start ()
    {
        LibraryData libraryData = new LibraryData();
        libraryData.actionCards = new List<CardData>();
        libraryData.bondageCards = new List<CardData>();
        libraryData.touchCards = new List<CardData>();

        CardData cardData = new CardData();
        cardData.title = "title text";
        cardData.text = "action text";
        cardData.intensity = 0;
        cardData.flavor = "flavor text";

        libraryData.actionCards.Add(cardData);


        cardData = new CardData();
        cardData.title = "title text";
        cardData.text = "touch text";
        cardData.intensity = 0;
        cardData.flavor = "flavor text";

        libraryData.touchCards.Add(cardData);


        cardData = new CardData();
        cardData.title = "title text";
        cardData.text = "bondage text";
        cardData.intensity = 0;
        cardData.flavor = "flavor text";

        libraryData.bondageCards.Add(cardData);

        CardLoaderSaver.SaveLibrary(libraryData);
    }

}
