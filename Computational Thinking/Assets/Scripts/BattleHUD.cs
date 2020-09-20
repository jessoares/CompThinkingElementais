using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{ 
	public Text currentHP;
	


	public void SetHP(Card unit,int hp)
	{
        currentHP.text = hp.ToString();
	}

}
