using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // find better link than gameobject
    public GameObject happyBarMeter;
    private float time;
    private UIView uiView;
    private UIMath uiMath;
    // happiness can be 0-100
    RectTransform rectTransform;
    

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        uiView = GetComponent<UIView>();
        uiMath = GetComponent<UIMath>();
        uiMath.happiness = 70;
        uiView.SetHappyBarSize(uiMath.happiness);
    }

    public void HappyBarLoosingHappiness()
    {

    }


    public void TestPlusButton()
    {
        uiMath.happiness = uiMath.IncrementChangeHappiness(uiMath.happiness);
        uiView.SetHappyBarSize(uiMath.happiness);
        uiView.uiMath.CheckRulesForHappiness();
        Debug.Log(uiMath.happiness);
    }

    public void TestMinusButton()
    {
        uiMath.happiness = uiMath.DecrementChangeHappiness(uiMath.happiness);
        uiView.SetHappyBarSize(uiMath.happiness);
        uiView.uiMath.CheckRulesForHappiness();
        Debug.Log(uiMath.happiness);
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
