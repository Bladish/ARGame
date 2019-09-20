using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TestController : MonoBehaviour
{
    private Save save;
    private Load load;
    private UIMath uiMath;
    private GameMath gameMath;
    private UIController uIController;
    private UIView uIView;
    public DateTime dateTime;
    public int day;
    public int hour;
    public int minute;
    public int second;
    void Start()
    {
        save = GetComponent<Save>();
        load = GetComponent<Load>();
        uiMath = GetComponent<UIMath>();
        gameMath = GetComponent<GameMath>();
        uIController = GetComponent<UIController>();
        uIView = GetComponent<UIView>();
        dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day, hour, minute, second);
    }

    void Update()
    {
        uIController.UIControllerUpdate();
        if (Input.GetKeyDown(KeyCode.P)) gameMath.CalculateLoadGameState();
        if (Input.GetKeyDown(KeyCode.S)) gameMath.GetingGameState();
        if (Input.GetKeyDown(KeyCode.L)) load.LoadGameState();
        if (Input.GetKeyDown(KeyCode.A)) save.SaveGameState(100, 60, dateTime);
        if (Input.GetKeyDown(KeyCode.Space)) uiMath.HungerLoss(gameMath.CalculateHappienessAndHungerLoss()); 

    }
}
