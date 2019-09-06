using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by Ulrik
/// </summary>

public class Eat : Player
{
	[SerializeField] private int hungerPoints;

	public Eat(int sethungerpoints)
	{
		hungerPoints = sethungerpoints;
	}

	public int HungerPointsChange
	{
		get => hungerPoints;
		set => hungerPoints = value;
	}
}


	//Do same as code above
	//This is how to use properties

	//public int HungerPoints { get; set; }
