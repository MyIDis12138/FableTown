using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private healthbar HPdisplay;
    public GameObject Bars;
    public GameObject DeathUI;

    private CharacterStates PlayerStates;
    private Animator Anima;
    private float lastTime=2f;
    // Start is called before the first frame update
    private void Awake()
    {
        HPdisplay = Bars.GetComponent<healthbar>();
        PlayerStates = GetComponent<CharacterStates>();
        HPdisplay.maxHealthValue( PlayerStates.maxHealth);
        PlayerStates.currentHealth = PlayerStates.maxHealth;
        Anima = GetComponent<Animator>();
        Anima.SetBool("Death", false);
    }

    public void refill()
    {
        PlayerStates.currentHealth = PlayerStates.maxHealth;
        //DeathUI.active = false;       
        Anima.SetBool("Death", false);
        Anima.SetTrigger("Refill");
        Time.timeScale = 1;

    }

    private void FixedUpdate()
    {
        HPdisplay.currentHealthValue(PlayerStates.currentHealth);
   
        if (PlayerStates.currentHealth <= 0)
        {
            Anima.SetBool("Death", true);
            lastTime -= Time.deltaTime;
            if (lastTime < 0)
            {
                setUI();
                lastTime = 2f;
            }

        }
    }
    void setUI()
    {
        DeathUI.active = true;
        Time.timeScale = 0;
    }



    // Update is called once per frame

}
