
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Card card;
    public int currentHealth;

    public void Start()
    {
       currentHealth = card.maxHP;
    }
    public void SetHp()
    {
        currentHealth = card.maxHP;
    }

    public bool TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}

