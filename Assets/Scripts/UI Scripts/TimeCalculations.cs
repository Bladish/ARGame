using System;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;

public class TimeCalculations : MonoBehaviour
{
    private DateTime now;
    private DateTime lastFeed;
    private DateTime lastPlayed;
    private TimeSpan timeDifference;
    private DateTime timeRules;
    private Double minutsToAdd = 1.00;
    private Double secondsToAdd = 10.00;

    void Start()
    {
        timeRules = DateTime.Now.AddSeconds(secondsToAdd);           
    }

    private void Update()
    {
        now = DateTime.Now;
    }

    public void Eating()
    {
        lastFeed = now;
        timeRules = now.AddMinutes(minutsToAdd);
    }

    public void CalculateTimeDifference()
    {
        timeDifference = now - lastFeed;
    }

    public DateTime GetNowTime()
    {
        return now;
    }

    public DateTime GetTimeRules()
    {
        return timeRules;
    }

    public void SetTimeRules(DateTime setTimeRules)
    {
        timeRules = setTimeRules;
    }

    public void AddSecondsToTimeRules()
    {
        timeRules = DateTime.Now.AddSeconds(secondsToAdd);
    }
}
