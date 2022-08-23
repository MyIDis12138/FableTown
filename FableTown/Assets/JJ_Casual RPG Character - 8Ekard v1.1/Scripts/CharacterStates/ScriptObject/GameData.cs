using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Data",menuName ="Character States")]
public class GameData : ScriptableObject
{
    [Header("Stats Info")]
    public int MaxHealth;

    public int CurrentHealth;

    public int BaseDefence;

    public int CurrentDefence;
}
