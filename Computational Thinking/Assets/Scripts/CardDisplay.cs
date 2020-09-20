using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image image;
    public Text name;
    public Text damage;
    public Text attackName;
    public Text currentHealth;
    public ParticleSystem attack;
    public Transform attackPoint;
    void Start()
    {
        image.sprite = card.image;
        name.text = card.name;
        damage.text = card.damage.ToString();
        attackName.text = card.attackName.ToString();
        currentHealth.text = card.currentHP.ToString();
        attack = card.attack;
    }
    public void SetHP(int hp)
    {
        currentHealth.text = hp.ToString();
    }



}
