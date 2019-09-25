using System;
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
    public int eating;
    public int playing;
    
    #region Hunger
    public void HungerLoss(int lossValue)
    {
        eating -= lossValue;
        eating = Mathf.Clamp(eating, 0, 100);
    }

    public void HungerGains(int gains)
    {
        eating +=  gains;
        eating = Mathf.Clamp(eating, 0, 100);
    }
    #endregion

    #region Happiness
    public void HappinessLoss(int lossValue)
    {
        playing -= lossValue;
        playing = Mathf.Clamp(playing, 0, 100);
    }

    public void HappienessGains(int gains)
    {
        playing += gains;
        playing = Mathf.Clamp(playing, 0, 100);
    }

    public int GetEating()
    {
        return eating;
    }

    public int GetPlaying()
    {
        return playing;
    }

    public void LifeTime()
    {

    }

    #endregion
}
