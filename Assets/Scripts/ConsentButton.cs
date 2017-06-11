using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ConsentButton : MonoBehaviour {

    Button _button;
    RectTransform _rectTransform;

    Vector2 _startWidth;
    Vector2 _smallWidth;


    void Awake()
    {
        _button = GetComponent<Button>();
        _rectTransform = transform.GetChild(0).GetComponentInChildren<RectTransform>();
        _startWidth = _rectTransform.sizeDelta;
        _smallWidth = _startWidth;
        _smallWidth.x = -1;
    }

	public void SetActivey(bool doActivey)
    {
        if (doActivey)
        {
            _button.enabled = doActivey;
            _rectTransform.DOSizeDelta(_startWidth, 0.2f);
        }
        else
        {
            _button.enabled = doActivey;
            _rectTransform.DOSizeDelta(_smallWidth, 0.2f);
        }
    }
}
