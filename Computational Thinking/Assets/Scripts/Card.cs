using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Card",menuName = "Card")]
public class Card : ScriptableObject
{
    public Sprite image;
    public string unitName;
    public int damage;
    public string attackName;
    public int currentHP;
    public int maxHP;
    public ParticleSystem attack;


    public void Start()
    {
        currentHP = maxHP;
    }


    public void setHP()
    {
        currentHP = maxHP;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            currentHP = maxHP;
            return true;
        }
        else
        {
            return false;
        }
    }



}
