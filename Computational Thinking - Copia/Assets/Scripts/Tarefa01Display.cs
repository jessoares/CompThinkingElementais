using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tarefa01Display : MonoBehaviour
{
    public Elemental card;
    public Image image;
     ParticleSystem attack;
    public bool inPlace;
   public bool isSel;
    string weakness;
     string strength;
  string type;

    void Start()
    {
        image.sprite = card.image;
        attack = card.attack;
        type = card.tipo;
        inPlace = false;
        isSel = false;
    }
  
}
