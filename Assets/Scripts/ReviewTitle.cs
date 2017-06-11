using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviewTitle : MonoBehaviour {

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();

        text.text = GameManager.Instance.SubViewDone ? "Chosen cards" : "Review cards";
    }
	
}
