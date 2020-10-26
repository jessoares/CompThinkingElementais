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
    public string[] weakness;
    public string[] strength;
    public string[] draw;
    public string type;

    void Start()
    {
        image.sprite = card.image;
        novoName.text = card.unitName;
        damage.text = card.damage.ToString();
        currentHealth.text = card.currentHP.ToString();
        attack = card.attack;
        weakness = card.fraquezas;
        strength = card.forte;
        draw = card.empate;
        type = card.tipo;
        inPlace = false;
    }
    public void SetHP(int hp)
    {
        currentHealth.text = hp.ToString();
    }
    


}
