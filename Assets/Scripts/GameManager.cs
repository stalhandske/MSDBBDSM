using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool SubViewDone;

	private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if (_instance != null)
                    DontDestroyOnLoad(_instance.gameObject);
            }
 
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start()
    {
		
    }
	
    void Update()
    {
		
    }

    public void GoToScene(string scene)
    {
    	SceneManager.LoadScene(scene);
    }
}
