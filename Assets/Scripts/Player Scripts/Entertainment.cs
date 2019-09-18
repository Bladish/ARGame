using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by Ulrik
/// Edited by Patrik
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
		set => funPoints = Mathf.Clamp(value, 1, 100);
	}
}
