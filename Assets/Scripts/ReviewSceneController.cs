using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviewSceneController : MonoBehaviour
{

    void Start()
    {

    	var spawner = FindObjectOfType<CardSpawner>();
		spawner.isSub = !GameManager.Instance.SubViewDone;
		spawner.Spawn();

		if (!GameManager.Instance.SubViewDone)
			GameManager.Instance.SubViewDone = true;
    }
	
    void Update()
    {
		
    }
}
