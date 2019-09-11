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
    private int lossValue = 1;
    [HideInInspector]   public int happiness;
    [HideInInspector]   public int changeInMood;


   
    
    public void MVPTimeCheck()
    {
        // TODO: Runs the check and the loss each frame during the full second elapsedtime = 10
        // FIX: just want to run once
        var elapsedTime = (int)Time.time;
       // Debug.Log( "TIME" + elapsedTime);
        if (elapsedTime % mVPTimeTick == 0)
        {
            Debug.Log("TIME" + elapsedTime);

            HungerLoss();
            HappinessLoss();
        }
    }

    //void TimeCheck()
    //{
    //    if (elapsedTime % happinessTick == 0)
    //    {
    //       //changeInMood = -1;
    //        //run funcion to change happibar
    //    }
    //}

    #region Hunger
    public void HungerLoss()
    {
        eat.HungerPointsChange -= lossValue;
    }

    public void TestHungerChange()
    {
        // REMINDER remove debug logs please
        Debug.Log("before hunger check" + eat.HungerPointsChange);
        eat.HungerPointsChange +=  eating;
        Debug.Log("after hunger check" + eat.HungerPointsChange);
    }
    #endregion

    #region Happiness
    public void HappinessLoss()
    {
        entertainment.FunPointsChange -= lossValue;
    }
    public void TestFunChange()
    {
        // REMINDER remove debug logs please
        Debug.Log("before fun check" + entertainment.FunPointsChange);
        entertainment.FunPointsChange += playing;
        Debug.Log("after fun check" + entertainment.FunPointsChange);
    }
    #endregion
    
}
