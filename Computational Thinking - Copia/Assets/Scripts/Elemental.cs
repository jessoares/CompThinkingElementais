using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Elemental", menuName = "Elemental")]
public class Elemental : ScriptableObject
{
    public Sprite image;
    public string unitName;
    public ParticleSystem attack;
    public string fraquezas;
    public string forte;
    public string tipo;
}
