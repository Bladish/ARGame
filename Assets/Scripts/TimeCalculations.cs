using System;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCalculations : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI timeSaved;
    public TextMeshProUGUI timeDif;
    public TextMeshProUGUI checkTimeRules;

    private DateTime now;
    private DateTime lastFeed;
    private DateTime lastPlayed;
    private TimeSpan timeDifference;
    private DateTime timeRules;
    private Double minutsToAdd = 1.00;
    void Start()
    {
               
    }

    private void Update()
    {
        now = DateTime.Now;
        time.text = now.ToString();
    }

    public void Eating()
    {
        lastFeed = now;
        timeRules = now.AddMinutes(minutsToAdd);
        timeSaved.text = lastFeed.ToString();
    }

    public void CalculateTimeDifference()
    {
        timeDifference = now - lastFeed;
        timeDif.text = timeDifference.ToString();
    }

    public void CheckTimeCalculations()
    {
        Debug.Log(timeRules);
        if (now > timeRules) checkTimeRules.text = "True";
        else checkTimeRules.text = "False";
    }

}
