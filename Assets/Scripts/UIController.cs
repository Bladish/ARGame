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


    // currently version 1 and 2 do the same thing. version 1 is preferable with working CheckRules 
    public void TestFunButton()
    {
        // version 1 
        uiMath.TestFunChange();
      //  uiMath.CheckRules(entertainment.FunPointsChange);
        uiView.SetHappyBarSize(uiMath.CheckRules(entertainment.FunPointsChange));
    }

    public void TestFeeding()
    {

    //version 2 
        uiMath.TestHungerChange();
        uiMath.CheckRules(eat.HungerPointsChange);
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
