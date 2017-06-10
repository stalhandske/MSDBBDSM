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
        cardData.subInstructions = "sub instructions";
        cardData.domInstructions = "dom instructions";
        cardData.intensity = 0;
        cardData.flavor = "flavor text";

        libraryData.actionCards.Add(cardData);
        libraryData.actionCards.Add(cardData);

        cardData = new CardData();
        cardData.title = "title text";
        cardData.subInstructions = "sub instructions";
        cardData.domInstructions = "dom instructions";
        cardData.intensity = 0;
        cardData.flavor = "flavor text";

        libraryData.touchCards.Add(cardData);
        libraryData.touchCards.Add(cardData);

        cardData = new CardData();
        cardData.title = "title text";
        cardData.subInstructions = "sub instructions";
        cardData.domInstructions = "dom instructions";
        cardData.intensity = 0;
        cardData.flavor = "flavor text";

        libraryData.bondageCards.Add(cardData);
        libraryData.bondageCards.Add(cardData);

        CardLoaderSaver.SaveLibrary(libraryData);
    }

}
