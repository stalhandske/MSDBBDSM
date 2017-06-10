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
	
    void Update()
    {
		
    }
}
