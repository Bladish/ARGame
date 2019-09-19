using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private int lastPlayedYear;
    private int lastPlayedMonth;
    private int lastPlayedDay;
    private int lastPlayedHour;
    private int lastPlayedMinute;
    private int lastPlayedSecond;
    private List<int> saveToPlayerPrefs = new List<int>();
    private List<String> keysToPlayerPrefs = new List<string>();

    private void Start()
    {
        keysToPlayerPrefs.Add("Year");
        keysToPlayerPrefs.Add("Month");
        keysToPlayerPrefs.Add("Day");
        keysToPlayerPrefs.Add("Hour");
        keysToPlayerPrefs.Add("Minute");
        keysToPlayerPrefs.Add("Second");
        keysToPlayerPrefs.Add("Health");
        keysToPlayerPrefs.Add("Happieness");
    }

    public void SaveGameState(int hunger, int happieness, DateTime dateTime)
    {
        saveToPlayerPrefs.Add(lastPlayedYear = dateTime.Year);
        saveToPlayerPrefs.Add(lastPlayedMonth = dateTime.Month);
        saveToPlayerPrefs.Add(lastPlayedDay = dateTime.Day);
        saveToPlayerPrefs.Add(lastPlayedHour = dateTime.Hour);
        saveToPlayerPrefs.Add(lastPlayedMinute = dateTime.Minute);
        saveToPlayerPrefs.Add(lastPlayedSecond = dateTime.Second);
        saveToPlayerPrefs.Add(hunger);
        saveToPlayerPrefs.Add(happieness);

        for (int i = 0; i < keysToPlayerPrefs.Count; i++)
        {
            PlayerPrefs.SetInt(keysToPlayerPrefs[i], saveToPlayerPrefs[i]);
            
        }
        saveToPlayerPrefs.Clear();
    }
}
