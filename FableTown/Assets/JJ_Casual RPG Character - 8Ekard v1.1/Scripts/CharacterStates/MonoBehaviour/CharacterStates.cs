using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStates : MonoBehaviour
{
    public GameData characterdata;
    public AttackData characterAttack;

    [HideInInspector]
    public bool isCritical;

    #region ReadAndSetData
    public int maxHealth
    {
        get
        {
            if (characterdata != null)
                return characterdata.MaxHealth;
            else
                return 0;
        }
        set
        {
            characterdata.MaxHealth = value;
        }
    }

    public int currentHealth
    {
        get
        {
            if (characterdata != null)
                return characterdata.CurrentHealth;
            else
                return 0;
        }
        set
        {
            characterdata.CurrentHealth = value;
        }
    }
    public int baseDefence
    {
        get
        {
            if (characterdata != null)
                return characterdata.BaseDefence;
            else
                return 0;
        }
        set
        {
            characterdata.BaseDefence = value;
        }
    }
    public int currentdefence
    {
        get
        {
            if (characterdata != null)
                return characterdata.CurrentDefence;
            else
                return 0;
        }
        set
        {
            characterdata.CurrentDefence = value;
        }
    }
    #endregion

    #region AttackData
    public float attackrange
    {
        get
        {
            if (characterAttack != null)
                return characterAttack.attackRange;
            else
                return 0;
        }
        set
        {
            characterAttack.coolDown = value;
        }
    }
    public float skillrange
    {
        get
        {
            if (characterAttack != null)
                return characterAttack.skillRange;
            else
                return 0;
        }
        set
        {
            characterAttack.coolDown = value;
        }
    }
    public float coolDown
    {
        get
        {
            if (characterAttack != null)
                return characterAttack.coolDown;
            else
                return 0;
        }
        set
        {
            characterAttack.coolDown = value;
        }
    }
    public int maxdamage
    {
        get
        {
            if (characterAttack != null)
                return characterAttack.maxDamge;
            else
                return 0;
        }
        set
        {
            characterAttack.maxDamge = value;
        }
    }

    public int mindamge
    {
        get
        {
            if (characterAttack != null)
                return characterAttack.minDamge;
            else
                return 0;
        }
        set
        {
            characterAttack.minDamge = value;
        }
    }

    #endregion

    #region Character Combat
    public void TakeDamage(CharacterStates attacker, CharacterStates defener)
    {
        int damage = Mathf.Max(attacker.CurrentDamage() - defener.currentdefence,0);
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        if (isCritical)
        {
            defener.GetComponent<Animator>().SetTrigger("Hit");
        }


        //Debug.Log("CurrentHealth: " + currentHealth);
        //Debug.Log(CurrentDamage());
        //TODO: Update UI;

    }

    private int CurrentDamage()
    {
        float coreDamage = UnityEngine.Random.Range(characterAttack.minDamge, characterAttack.maxDamge);
        if (isCritical)
            return (int)(coreDamage * characterAttack.criticalMultiplier);
        else
            return (int)coreDamage;
    }

    #endregion
}
