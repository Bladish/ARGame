using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHappyBars : MonoBehaviour
{
    private UIMath uiMath;
    void Start()
    {
        uiMath = GetComponent<UIMath>();
    }
    public void AddHappyness()
    {
        uiMath.HappienessGains(20);
    }

    public void THEFUCKINGCOCKISEATING()
    {
        uiMath.HungerGains(20);
    }
}
