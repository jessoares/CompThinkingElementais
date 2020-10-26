
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public Card card;
    public int currentHealth;

    

   public void SetStats()
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

