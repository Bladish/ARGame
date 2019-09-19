using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Load : MonoBehaviour
{
    public static DateTime loadedGameTime;
    public static int loadedHunger;
    public static int loadedHappieness;
  
    void Awake()
    {
        LoadGameState();
    }
    public void LoadGameState()
    {
        loadedGameTime = new DateTime(PlayerPrefs.GetInt("Year"), PlayerPrefs.GetInt("Month"), PlayerPrefs.GetInt("Day"), PlayerPrefs.GetInt("Hour"), PlayerPrefs.GetInt("Minute"), PlayerPrefs.GetInt("Second"));
        loadedHunger = PlayerPrefs.GetInt("Health");
        loadedHappieness = PlayerPrefs.GetInt("Happieness");
        Debug.Log("Loaded Game time " + loadedGameTime + " Health " + loadedHunger + " Happieness " + loadedHappieness);
    }
}
