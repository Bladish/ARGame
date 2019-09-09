using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSingelton : MonoBehaviour
{

    public static AnchorSingelton instance;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

    }
}