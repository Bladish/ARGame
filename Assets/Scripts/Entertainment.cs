using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by Ulrik
/// </summary>

public class Entertainment : Player
{
	[SerializeField] private int funPoints;

	public Entertainment(int setFunPoints)
	{
		funPoints = setFunPoints;
	}

	public int FunPointsChange
	{
		get => funPoints;
		set => funPoints = value;
	}
}


	//private int eating = 100;
	//private int whenEating
	//Eat eat;

	//private void Start()
	//{
	//	eat = new Eat(eating);
	//	Test();
	//}


	//public void Test()
	//{
	//	Debug.Log(eat.HungerPointsChange);
	//	eat.HungerPointsChange = eating + whenEating;
	//	Debug.Log(eat.HungerPointsChange);
	//}
