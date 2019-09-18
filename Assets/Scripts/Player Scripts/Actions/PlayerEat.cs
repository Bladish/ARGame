using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
/// <Author>
/// Jonathan Aronsson Olsson
/// Michael Håkansson
/// </Author>
/// <summary>
/// Player eat functionality
/// </summary>
public class PlayerEat : MonoBehaviour
{
    private int limit;
    public int hungerPoints;

    public void PlayerEating(int gettingFat)
    {
        hungerPoints += gettingFat;
    }

    public void LoseHungerPoints(int lossHungerPoints)
    {
        hungerPoints -= lossHungerPoints;
    }
    //TODO Fix CheckingHungerPoints
    public void CheckingHungerPoints()
    {
        if(hungerPoints > limit)
        {

        }
    }
}
