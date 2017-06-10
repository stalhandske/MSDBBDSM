using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
	public Text TitleScreenText;
	public Button PressPlayButton;

	public Text DisclaimerText;
	public Button ConsentButton;
	public Button NoConsentButton;

    void Start()
    {
    }
	
    void Update()
    {
		
    }

    public void PressPlay()
    {
        SceneManager.LoadScene("2 - ChooseYourTouchesNew");

        // Go to Disclaimer
        // Hide TitleText and Play Button
     //   ShowTitleScreenUI(false);
    	//ShowDisclaimerUI(true);
    }

    public void Consent()
    {
    	// Go to Card choosing scene
    	SceneManager.LoadScene("2 - ChooseYourTouchesNew");
    }

    public void NoConsent()
    {
    	// Go back to Title screen
    	// hide Disclaimer UI

    	ShowTitleScreenUI(true);
    	ShowDisclaimerUI(false);
    }

    void ShowTitleScreenUI (bool show)
    {
    	TitleScreenText.enabled = show;
    	ShowButton(PressPlayButton, show);
    }

    void ShowDisclaimerUI(bool show)
    {
    	DisclaimerText.enabled = show;
    	ShowButton(ConsentButton, show);
    	ShowButton(NoConsentButton, show);
    }

    void ShowButton(Button b, bool show)
    {
    	b.GetComponent<Image>().enabled = show;
    	b.GetComponentInChildren<Text>().enabled = show;
    }
}
