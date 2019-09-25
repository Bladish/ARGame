using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    GameController gameController;

    void Start()
    {
        gameController = GetComponent<GameController>();
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        gameController.SetGameStart();
    }
}
