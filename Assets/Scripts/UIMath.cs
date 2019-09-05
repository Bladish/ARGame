using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMath : UIController
{
    private float elapsedTime ;
    private float happinessTick = 432;
    public int happiness;
    public int changeInMood;
    
    // Start is called before the first frame update
    
    void TimeCheck()
    {
        if (elapsedTime % happinessTick == 0)
        {
           //changeInMood = -1;
            //run funcion to change happibar
        }
    }

    public int IncrementChangeHappiness(int oldHappiness)
    {
        int temp = oldHappiness;
        temp++;
        return temp;
    }

    public int DecrementChangeHappiness(int oldHappiness)
    {
        int temp = oldHappiness;
        temp--;
        return temp;
    }

    public void CheckRulesForHappiness()
    {
        //happyBarMeter.GetComponent<RectTransform>();

        // changes happiness according to the change designated by controller
        if (happiness > 100)
        {
            happiness = 100;
        }
        if (happiness < 1)
        {
            happiness = 1;
        }
        // at the end run happinescolor
    }
}
