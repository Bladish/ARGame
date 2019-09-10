using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by Joakim
/// Edited by Ulrik
/// Edited by Patrik
/// </summary>

public class UIController : MonoBehaviour
{
    protected Eat eat;
    protected Entertainment entertainment;
    private float time;
    private UIView uiView;
    private UIMath uiMath;
    RectTransform rectTransform;



    //private void Update()
    //{
    //    uiMath.MVPTimeCheck();
    //    uiView.SetHungerBarMeter(eat.HungerPointsChange);
    //    uiView.SetHappyBarSize(entertainment.FunPointsChange);
    //}

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        uiView = GetComponent<UIView>();
        uiMath = GetComponent<UIMath>();
        eat = GetComponent<Eat>();
        entertainment = GetComponent<Entertainment>();

        uiView.SetHungerBarMeter(eat.HungerPointsChange);
        uiView.SetHappyBarSize(entertainment.FunPointsChange);
    }

    public void HappyBarLosingHappiness()
    {

    }


    public void TestFunButton()
    {
        uiMath.TestFunChange();
        uiView.SetHappyBarSize(entertainment.FunPointsChange);
    }

    public void TestFeeding()
    {
        uiMath.TestHungerChange();
        uiView.SetHungerBarMeter(eat.HungerPointsChange);
        
    }

    void HappinessColor ()
    {
        //checks the % of happiness
        //changes the color  of happybar 
        // 60-100 green
        //40- 60 yellow
        // 0-40 red
    }
}
