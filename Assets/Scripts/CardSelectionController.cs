using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamelogic;
using UnityEngine.SceneManagement;

public class CardSelectionController : MonoBehaviour
{
    public enum CardSelectionState
    {
        ChooseTouch,
        ChooseBondage,
        ChooseAction
    }

    public Text TitleText;
    public int NumActionCards = 4;

    private StateMachine<CardSelectionState> _stateMachine;
    private CardSpawner _spawner;
    [SerializeField]
    private int _actionCardsSelected;

    void Start()
    {
        _spawner = FindObjectOfType<CardSpawner>();

        _stateMachine = new StateMachine<CardSelectionState>(); 
        _stateMachine.AddState(CardSelectionState.ChooseBondage, ChooseBondageStart, ChooseBondageUpdate, ChooseBondageStop);
        _stateMachine.AddState(CardSelectionState.ChooseTouch, ChooseTouchStart, ChooseTouchUpdate, ChooseTouchStop);
        _stateMachine.AddState(CardSelectionState.ChooseAction, ChooseActionStart, ChooseActionUpdate, ChooseActionStop);
        _stateMachine.CurrentState = CardSelectionState.ChooseTouch;
    }
    
    void Update()
    {
        _stateMachine.Update();
    }

    // Choose Touches State
    void ChooseTouchStart()
    {
        TitleText.text = "Choose Your Touches";
        _spawner.ClearCards();
        _spawner.Spawn(1, false, 3);
    }

    void ChooseTouchUpdate()
    {

    }

    void ChooseTouchStop()
    {

    }

    // Choose Bondage State
    void ChooseBondageStart()
    {
        TitleText.text = "Choose Your Bondage";
        _spawner.ClearCards();
        _spawner.Spawn(0, false, 3);
    }

    void ChooseBondageUpdate()
    {

    }

    void ChooseBondageStop()
    {

    }

    // Choose Actions State
    void ChooseActionStart()
    {
        TitleText.text = "Choose Your Actions";
        _spawner.ClearCards();
        _spawner.Spawn(2, false, 3);
    }

    void ChooseActionUpdate()
    {

    }

    void ChooseActionStop()
    {

    }

    public void ConsentButtonPressed()
    {
        switch (_stateMachine.CurrentState)
        {
            case CardSelectionState.ChooseTouch:
                _stateMachine.CurrentState = CardSelectionState.ChooseBondage;
                break;

            case CardSelectionState.ChooseBondage:
                _stateMachine.CurrentState = CardSelectionState.ChooseAction;
                break;

            case CardSelectionState.ChooseAction:
                {
                    _actionCardsSelected++;   
                    if (_actionCardsSelected < 4)
                        _stateMachine.CurrentState = CardSelectionState.ChooseAction;
                    else
                    {
                        print(Deck.deckTouches.Count + " - " + Deck.deckTouches[0].title);
                        _stateMachine.CurrentState = CardSelectionState.ChooseAction;
                        SceneManager.LoadScene("4 - SubReview");
                    }
                }
                break;
        }
    }
}
