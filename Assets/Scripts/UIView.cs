using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : UIController
{
    
    private int height = 30;
    private int width;


    public void SetHappyBarSize(int happiness)
    {
        width = happiness * 2;
        var happyBarMeterRectTransform = happyBarMeter.transform as RectTransform;
        happyBarMeterRectTransform.sizeDelta = new Vector2(width, height);
    }
}
