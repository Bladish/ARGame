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
    Touch screenTouch;



    public void UpdateTouch()
    {
        if (Input.touchCount < 1 || (screenTouch = InstantPreviewInput.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        else if (InstantPreviewInput.touchCount > 0 && (screenTouch = InstantPreviewInput.GetTouch(0)).phase == TouchPhase.Began)
        {
            screenTouch = InstantPreviewInput.GetTouch(0);
        }

    }

    public Touch SendTouch()
    {
        UpdateTouch();
        return screenTouch;
    }
    
}
