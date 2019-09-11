using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Created by Joakim
/// Edited by Ulrik
/// Edited by Patrik
/// </summary>
public class UIMath : UIController
{
   // private float happinessTick = 432;
    private int mVPTimeTick = 10;
    private int eating = 10;
    private int playing = 10;
    [HideInInspector]   public int happiness;
    [HideInInspector]   public int changeInMood;

 
    #region Hunger
    public void HungerLoss(int lossValue)
    {
        eat.HungerPointsChange -= lossValue;
    }

    public void HungerGains(int gains)
    {
        eat.HungerPointsChange +=  gains;
    }
    #endregion

    #region Happiness
    public void HappinessLoss(int lossValue)
    {
        entertainment.FunPointsChange -= lossValue;
    }

    public void HappienessGains(int gains)
    {
        entertainment.FunPointsChange += gains;
    }

    #endregion
}
