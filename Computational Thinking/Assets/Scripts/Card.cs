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
    public int currentHP;
    public int maxHP;
    public ParticleSystem attack;
    public string[] fraquezas;
    public string[] forte;
    public string[] empate;
    public string tipo;


    public void Start()
    {
        currentHP = maxHP;
    }


    public void setHP()
    {
        currentHP = maxHP;
    }

  



}
