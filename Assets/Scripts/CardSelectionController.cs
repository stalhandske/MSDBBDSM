using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamelogic;

public class CardSelectionController : MonoBehaviour
{
	public enum CardSelectionState
	{
		ChooseTouch,
		ChooseBondage,
		ChooseAction
	}

	public Text TitleText;
	public CardView Cards;

	private StateMachine<CardSelectionState> _stateMachine;

    void Start()
    {
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

    }

    void ChooseActionUpdate()
    {

    }

    void ChooseActionStop()
    {

    }
}
