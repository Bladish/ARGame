﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Author>
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Statemachine for the games buttons
/// </summary>
public class ButtonStateMachine : MonoBehaviour
{
    public enum ButtonState
    {
        IDLEBUTTON,
        FOODBUTTON,
        PLAYBUTTON,
        PETBUTTON
    }
    public ButtonState buttonState;
    StateMachineManager stateMachineManager;

    private void Start()
    {
        stateMachineManager = GetComponent<StateMachineManager>();
    }

    public ButtonState ButtonStateMachineUpdate()
    {
        switch (buttonState)
        {
            case ButtonState.IDLEBUTTON:
                Debug.Log("Pressed the Idle Button");
                break;
            case ButtonState.FOODBUTTON:
                Debug.Log("Pressed the Food Button");
                break;
            case ButtonState.PLAYBUTTON:
                Debug.Log("Pressed the Play Button");
                break;
            case ButtonState.PETBUTTON:
                Debug.Log("Pressed the Pet Button");
                break;
            default:
                break;
        }
        return buttonState;
    }

    public void PetButton()
    {
        buttonState = ButtonState.PETBUTTON;
    }
    public void FoodButton()
    {
        buttonState = ButtonState.FOODBUTTON;
    }
    public void IdleButton()
    {
        buttonState = ButtonState.IDLEBUTTON;
    }
    public void PlayButton()
    {
        buttonState = ButtonState.PLAYBUTTON;
    }

    public ButtonState GetButtonState() {
        return buttonState;
    }
}
