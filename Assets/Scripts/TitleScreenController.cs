using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
	void Start()
    {
    }
	
    void Update()
    {
		
    }

    public void PressPlay(string scene)
    {
        GameManager.Instance.GoToScene(scene);
    }
}
