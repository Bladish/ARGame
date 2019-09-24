using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by Joakim
/// Edited by Ulrik
/// Edited by Patrik
/// </summary>

public class UIController : MonoBehaviour
{
    //protected Eat eat;
    //protected Entertainment entertainment;
    [HideInInspector]
    public UIView uiView;
    [HideInInspector]
    public UIMath uiMath;
    


    //  TODO: when working rename to UIUpdate() and link in GameController 
    public void UIControllerUpdate()
    {
        SetBars();
    }
    //Numbers below shoud come from GameController
    void Start()
    {
        uiView = GetComponent<UIView>();
        uiMath = GetComponent<UIMath>();
        //eat = GetComponent<Eat>();
        //entertainment = GetComponent<Entertainment>();
        //Numbers below shoud come from GameController
        uiMath.HungerGains(100);
        uiMath.HappienessGains(100);
    }

    private void SetBars()
    {
        uiView.SetHungerBarMeter(uiMath.GetEating());
        uiView.SetHappyBarSize(uiMath.GetPlaying());
    }
    
    void HappinessColor ()
    {
        //checks the % of happiness
        //changes the color  of happybar 
        // 60-100 green
        //40- 60 yellow
        // 0-40 red
    }

    public void LifeLossForPlayer(int i)
    {
       uiMath.HappinessLoss(i);
       uiMath.HungerLoss(i);
    }

    public void LifeLossForPlayerOnGameStart(int i)
    {
        uiMath.HappinessLoss(i);
        uiMath.HungerLoss(i);
    }
}
