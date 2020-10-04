using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image image;
    public Text novoName;
    public Text damage;
    public Text attackName;
    public Text currentHealth;
    public ParticleSystem attack;
    public bool inPlace;
    void Start()
    {
        image.sprite = card.image;
        novoName.text = card.unitName;
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
