using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView
{
	public Text title;
    public Text subInstructions;
    public Text domInstructions;
    public Text flavor;

    public CardView()
    {
    	title.text = "Title";
    	subInstructions.text = "Sub Instructions";
    	domInstructions.text = "Dom Instructions";
    	flavor.text = "Flavor";
    }

    public void SetCardView()
    {
    	title.text = "Title";
    	subInstructions.text = "Sub Instructions";
    	domInstructions.text = "Dom Instructions";
    	flavor.text = "Flavor";
    }
}
