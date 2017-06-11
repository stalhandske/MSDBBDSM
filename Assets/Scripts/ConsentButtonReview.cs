using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsentButtonReview : MonoBehaviour {

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();

        text.text = GameManager.Instance.SubViewDone ? "Reset game" : "Accept";
    }
}
