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
    private float elapsedTime;
    private float happinessTick = 432;
    private float mVPTimeTick = 10;
    private int eating = 10;
    private int playing = 10;
    private int lossValue = 1;
    [HideInInspector]   public int happiness;
    [HideInInspector]   public int changeInMood;
    internal object nummer;


    //private void Start()
    //{
    //    elapsedTime = Time.time;
    //}
    //public void MVPTimeCheck()
    //{
    //    if (Time.time % mVPTimeTick == 0)
    //    {
    //        eat.HungerPointsChange -= lossValue;
    //        entertainment.FunPointsChange -= lossValue;   
            
            
    //    }

    //} 

    void TimeCheck()
    {
        if (elapsedTime % happinessTick == 0)
        {
           //changeInMood = -1;
            //run funcion to change happibar
        }
    }

  

    public void TestHungerChange()
    {
        // REMINDER remove debug logs please
        Debug.Log("before hunger check" + eat.HungerPointsChange);
        eat.HungerPointsChange +=  eating;

        Debug.Log("after hunger check" + eat.HungerPointsChange);
        
     
    }
    public void TestFunChange()
    {
        // REMINDER remove debug logs please
        Debug.Log("before fun check" + entertainment.FunPointsChange);
        entertainment.FunPointsChange += playing;
     
        Debug.Log("after fun check" + entertainment.FunPointsChange);


    }




    //// Does not work yet temporary ruleschecks in place, lookat Testfunchange and TestHungerChange
    //public int  CheckRules(int number)
    //{
    //    number = Mathf.Clamp(number, 1, 100);

    //    if (number > 100)
    //    {
    //        number = 100;
    //    }
    //    if (number < 1)
    //    {
    //        number = 1;
    //    }
    //    Debug.Log("NUMMER"+number);
       
    //    return number;


    //    // at the end run happinescolor
    //}
}
