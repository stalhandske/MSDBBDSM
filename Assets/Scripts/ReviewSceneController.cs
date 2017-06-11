using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewSceneController : MonoBehaviour
{

    void Start()
    {
        var spawner = FindObjectOfType<CardSpawner>();
        spawner.isSub = !GameManager.Instance.SubViewDone;
        spawner.Spawn();
    }
	
    public void GoToScene()
    {
        if (GameManager.Instance.SubViewDone)
        {
            Deck.Clear();
            GameManager.Instance.SubViewDone = false;
            GameManager.Instance.GoToScene("1 - TitleScreen");
        }
        else
        {
            GameManager.Instance.SubViewDone = true;
            GameManager.Instance.GoToScene("5 - AfterReview");
        }
    }
}
