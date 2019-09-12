using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
/// <Author>
/// Michael Håkansson
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Handle touch 
/// </summary>
public class TouchManager : MonoBehaviour
{
    public Touch screenTouch;
    private int touchIndex;


    public void UpdateTouch()
    {
        if (InstantPreviewInput.touchCount < 1 && (screenTouch = InstantPreviewInput.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        else if (InstantPreviewInput.touchCount > 0 && (screenTouch = InstantPreviewInput.GetTouch(0)).phase == TouchPhase.Began)
        {
            Debug.Log("Got Touch");
            screenTouch = InstantPreviewInput.GetTouch(0);
        }
    }

    public Touch GetTouch()
    {
        UpdateTouch();
        return screenTouch;
    }
    public int GetTouchIndex()
    {
        touchIndex = InstantPreviewInput.GetTouch(0).fingerId;
        return touchIndex;
    }
    
}
