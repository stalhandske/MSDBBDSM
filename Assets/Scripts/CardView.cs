using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Text title;
    public Text instructions;
    public Text flavor;
    public bool isSub;

    public void Start()
    {

    }

    public void SetCardView(CardData card)
    {
        title.text = card.title;
        instructions.text = isSub ? card.subInstructions : card.domInstructions;
        flavor.text = card.flavor;
    }
}
