using System;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;

public class TimeCalculations : MonoBehaviour
{
    private DateTime now;
    private DateTime timeRules;
    private DateTime lastPlayed;
    private readonly Double minutsToAdd = 14.00;
    private readonly Double secondsToAdd = 24.00;
    private PlayerPrefs timeSave;
    void Start()
    {
        now = DateTime.Now;
    }

    private void Update()
    {
        now = DateTime.Now;
    }

    public void Eating()
    {
        AddTimeToTimeRules();
    }


    public DateTime GetNowTime()
    {
        return now;
    }

    public DateTime GetTimeRules()
    {
        return timeRules;
    }

    public void AddTimeToTimeRules()
    {
        timeRules = DateTime.Now.AddMinutes(minutsToAdd).AddSeconds(secondsToAdd) ;
    }
}
