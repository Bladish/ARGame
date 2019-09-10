using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by Ulrik
/// Edited by Patrik
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
		set => hungerPoints = Mathf.Clamp(value, 1, 100);
    }
}
