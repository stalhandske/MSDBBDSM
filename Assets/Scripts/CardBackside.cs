using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBackside : MonoBehaviour {

    Image _image;

	void Awake()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        if ((transform.eulerAngles.y > -90 && transform.eulerAngles.y < 90) || transform.eulerAngles.y > 270)
        {
            _image.enabled = false;
        }
        else
        {
            _image.enabled = true;
        }
    }
}
