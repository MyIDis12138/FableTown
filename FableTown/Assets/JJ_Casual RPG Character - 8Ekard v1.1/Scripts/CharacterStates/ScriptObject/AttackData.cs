using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="New Attack", menuName = "Attack Data")]

public class AttackData : ScriptableObject
{
    public float attackRange;
    public float skillRange;
    public float coolDown;
    public int minDamge;
    public int maxDamge;

    public float criticalMultiplier;
    public float criticalChance;
}
