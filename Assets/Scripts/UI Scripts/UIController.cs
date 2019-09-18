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
    private UIView uiView;
    private UIMath uiMath;
    private TimeCalculations timeCalcuations;
    


    //  TODO: when working rename to UIUpdate() and link in GameController 
    private void Update()
    {
        LifeLossForPlayerSeconds();
        SetBars();
        uiMath.UIMathUpdate();
    }
    //Numbers below shoud come from GameController
    void Start()
    {
        uiView = GetComponent<UIView>();
        uiMath = GetComponent<UIMath>();
        //eat = GetComponent<Eat>();
        timeCalcuations = GetComponent<TimeCalculations>();
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

    public void LifeLossForPlayerSeconds()
    {
        if (timeCalcuations.GetNowTime() > timeCalcuations.GetTimeRules())
        {
            uiMath.HappinessLoss(1);
            uiMath.HungerLoss(1);
            timeCalcuations.AddSecondsToTimeRules();
        }
    }
}
