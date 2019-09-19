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
    
    public void UIMathUpdate()
    {
        eating = Mathf.Clamp(eating, 0, 100);
        playing = Mathf.Clamp(playing, 0, 100);
    }
    #region Hunger
    public void HungerLoss(int lossValue)
    {
        eating -= lossValue;
    }

    public void HungerGains(int gains)
    {
        eating +=  gains;
    }
    #endregion

    #region Happiness
    public void HappinessLoss(int lossValue)
    {
        playing -= lossValue;
    }

    public void HappienessGains(int gains)
    {
        playing += gains;
    }

    public int GetEating()
    {
        return eating;
    }

    public int GetPlaying()
    {
        return playing;
    }

    #endregion
}
