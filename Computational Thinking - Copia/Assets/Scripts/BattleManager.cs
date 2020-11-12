using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Card[] tsunami;
    public Card[] torrao;
    public Card[] rochoso;
    public Card[] fogareu;
    public Card[] eletron;
    public Card figueira;
    public Card carnivora;
    public Card trovoada;
    public Card tocha;
    public Card marinho;
    public GameObject battleSystem;
    public int mestre;
    int size;

    public void Update()
    {
        if (battleSystem.GetComponent<BattleSystemFinal>().battleWon == true)
        {
            if (mestre == 1)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[3].GetComponent<CardDisplay>().card = tsunami[1];
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[3].GetComponent<PlayerStats>().SetHp();
            }
            if (mestre == 2)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[4].GetComponent<CardDisplay>().card = torrao[1];
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[4].GetComponent<PlayerStats>().SetHp();
            }
            if (mestre == 3)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[5].GetComponent<CardDisplay>().card = rochoso[1];
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[5].GetComponent<PlayerStats>().SetHp();
            }
            if (mestre == 4)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[6].GetComponent<CardDisplay>().card = fogareu[1];
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[6].GetComponent<PlayerStats>().SetHp();
            }
            if (mestre == 5)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[7].GetComponent<CardDisplay>().card = eletron[1];
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[7].GetComponent<PlayerStats>().SetHp();
            }
            if (mestre == 6)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[8].GetComponent<CardDisplay>().card = figueira;
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[8].GetComponent<PlayerStats>().SetHp();
            }
            if (mestre == 7)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[9].GetComponent<CardDisplay>().card = trovoada;
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[9].GetComponent<PlayerStats>().SetHp();
            }
        }
        if (battleSystem.GetComponent<BattleSystemFinal>().battleOver == true)
        {
            SetLife();
        }
    }

    public void SetLife()
    {
         for (int i = 0; i < battleSystem.GetComponent<BattleSystemFinal>().playerCards.Length; i++)
         {
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
         }

        
    }

    public void PickEstacao()
    {
        battleSystem.SetActive(true);

        mestre = 5;
        battleSystem.GetComponent<BattleSystemFinal>().index = 2;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = eletron[0];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = eletron[1];
        battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
    }
    public void PickVulcao()
    {
        mestre = 4;
        battleSystem.SetActive(true);
        battleSystem.GetComponent<BattleSystemFinal>().index = 3;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = tocha;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = fogareu[0];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = fogareu[1];
        battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
    }
    public void PickPraia()
    {
        mestre = 1;
        battleSystem.SetActive(true);
        battleSystem.GetComponent<BattleSystemFinal>().index = 3;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = marinho;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = tsunami[0];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = tsunami[1];
        battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
    }
    public void PickUsina()
    {
        mestre = 7;
        battleSystem.SetActive(true);
        battleSystem.GetComponent<BattleSystemFinal>().index = 3;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = eletron[1];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = eletron[1];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = trovoada;
        battleSystem.GetComponent<BattleSystemFinal>().SetBattle();

    }
    public void PickArvore()
    {
        mestre = 6;
        battleSystem.SetActive(true);
        battleSystem.GetComponent<BattleSystemFinal>().index = 3;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = carnivora;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = figueira;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = figueira;
        battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
    }
    public void PickCaverna()
    {
        mestre = 2;
        battleSystem.SetActive(true);
        battleSystem.GetComponent<BattleSystemFinal>().index = 2;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = torrao[0];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = torrao[1];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = rochoso[1];
        battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
    }
    public void PickMontanha()
    {
        mestre = 3;
        battleSystem.SetActive(true);
        battleSystem.GetComponent<BattleSystemFinal>().index = 3;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = rochoso[0];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = rochoso[1];
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = torrao[1];
        battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
    }

}
