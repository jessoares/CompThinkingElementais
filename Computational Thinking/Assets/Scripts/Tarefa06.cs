using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tarefa06 : MonoBehaviour
{

    public GameObject battleSystem;
    public CanvasEffects Canvas;
    public DialogueManager manager;

    public int count;

    float nextSentenceTime = 0f;
    public float sentenceRate;
    public GameObject opponent1;
    public GameObject card;
    public GameObject card2;
    public GameObject[] playerCards;
    public GameObject attackButton;
    public GameObject nextButton;
    public GameObject textBox;
    public GameObject enemyCardPos;
    string sentence;
    public bool isQuestion;


    public int numberOfCards;

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
    public int mestre;
    int size;


    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 55;
        numberOfCards = 3;


    }
    public void Update()
    {
        if (Time.time >= nextSentenceTime && isQuestion == false)
        {
            nextButton.SetActive(true);
        }
    }
    public void BattleEnd()
    {
        if (battleSystem.GetComponent<BattleSystemFinal>().battleOver == true)
        {
            attackButton.SetActive(false);
            if (battleSystem.GetComponent<BattleSystemFinal>().battleWon == true)
            {
                if (mestre == 1)
                {
                    textBox.SetActive(true);
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da praia!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = tsunami[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = tsunami[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                }
                if (mestre == 2)
                {

                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da caverna!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = torrao[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = torrao[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                }
                if (mestre == 3)
                {
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da montanha!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = rochoso[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = rochoso[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                }
                if (mestre == 4)
                {

                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre do vulcão!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = fogareu[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = fogareu[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                }
                if (mestre == 5)
                {

                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da sub-estação!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = eletron[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = eletron[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                }
                if (mestre == 6)
                {

                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da árvore!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = figueira;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = figueira;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                }
                if (mestre == 7)
                {

                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da usina!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = trovoada;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = trovoada;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                }
                for (int i = 0; i < numberOfCards; i++)
                {
                    playerCards[i].SetActive(false);
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                }
                attackButton.SetActive(false);
                opponent1.SetActive(false);
                enemyCardPos.SetActive(false);
                //SetLife();
            }
            else
            {
                manager.GetComponent<DialogueManager>().DialogueText.text = "Parece que você perdeu dessa vez, mas não desista!";
            }

        }
    }
   

    public void NextSceneScript()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        nextButton.SetActive(false);
        count--;

        if (count == 40)
        {
            nextButton.SetActive(false);
            textBox.SetActive(false);
            isQuestion = true;
        }
        if(count == 41)
        {
            playerCards[0].SetActive(true);
            playerCards[1].SetActive(true);
            playerCards[2].SetActive(true);
        }
        if (count == 55)
        {
            Canvas.Fade();
        }

    }





    public IEnumerator WaitDialogue()
    {
        yield return new WaitForSeconds(1f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
    }
  
    public IEnumerator WaitDialogueDrag()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
        nextSentenceTime = 0f;

    }
    public IEnumerator Wait2DialogueDrag()
    {
        yield return new WaitForSeconds(3f);

        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;


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
        textBox.SetActive(true);
    mestre = 5;
        for (int i = 0; i < numberOfCards; i++)
        {
            playerCards[i].SetActive(true);
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
        }
        attackButton.SetActive(true);
        nextButton.SetActive(false);
        opponent1.SetActive(true);
        enemyCardPos.SetActive(true);
        isQuestion = true;
        battleSystem.GetComponent<BattleSystemFinal>().index = 1;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = eletron[1];
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = eletron[0];
    battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
}
public void PickVulcao()
{
        textBox.SetActive(true);
        mestre = 4;
        for (int i = 0; i < numberOfCards; i++)
        {
            playerCards[i].SetActive(true);
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
        }
        attackButton.SetActive(true);
        nextButton.SetActive(false);
        opponent1.SetActive(true);
        enemyCardPos.SetActive(true);
        isQuestion = true;
        battleSystem.GetComponent<BattleSystemFinal>().index = 2;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = tocha;
        battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = tocha;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = fogareu[0];
    battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
}
public void PickPraia()
{
        textBox.SetActive(true);
        mestre = 1;
        for (int i = 0; i < numberOfCards; i++)
        {
            playerCards[i].SetActive(true);
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
        }
        attackButton.SetActive(true);
        nextButton.SetActive(false);
        opponent1.SetActive(true);
        enemyCardPos.SetActive(true);
        isQuestion = true;
        battleSystem.GetComponent<BattleSystemFinal>().index = 2;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = marinho;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = tsunami[0];
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = tsunami[0];
    battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
}
public void PickUsina()
{
        textBox.SetActive(true);
        mestre = 7;
        for (int i = 0; i < numberOfCards; i++)
        {
            playerCards[i].SetActive(true);
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
        }
        attackButton.SetActive(true);
        nextButton.SetActive(false);
        opponent1.SetActive(true);
        enemyCardPos.SetActive(true);
        isQuestion = true;
        battleSystem.GetComponent<BattleSystemFinal>().index = 2;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = eletron[0];
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = eletron[1];
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = trovoada;
    battleSystem.GetComponent<BattleSystemFinal>().SetBattle();

}
public void PickArvore()
{
        textBox.SetActive(true);
        mestre = 6;
        for (int i = 0; i < numberOfCards; i++)
        {
            playerCards[i].SetActive(true);
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
        }
        attackButton.SetActive(true);
        nextButton.SetActive(false);
        opponent1.SetActive(true);
        enemyCardPos.SetActive(true);
        isQuestion = true;
        battleSystem.GetComponent<BattleSystemFinal>().index = 2;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = carnivora;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = figueira;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = carnivora;
    battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
}
public void PickCaverna()
{
        textBox.SetActive(true);
        mestre = 2;
        for (int i = 0; i < numberOfCards; i++)
        {
            playerCards[i].SetActive(true);
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
        }
        attackButton.SetActive(true);
        nextButton.SetActive(false);
        opponent1.SetActive(true);
        enemyCardPos.SetActive(true);
        isQuestion = true;
        battleSystem.GetComponent<BattleSystemFinal>().index = 1;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = torrao[0];
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = rochoso[0];
    battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
}
public void PickMontanha()
{
        textBox.SetActive(true);
        mestre = 3;
        for (int i = 0; i < numberOfCards; i++)
        {
            playerCards[i].SetActive(true);
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
        }
        attackButton.SetActive(true);
        nextButton.SetActive(false);
        opponent1.SetActive(true);
        enemyCardPos.SetActive(true);
        isQuestion = true;
        battleSystem.GetComponent<BattleSystemFinal>().index = 2;
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = rochoso[0];
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = rochoso[0];
    battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = torrao[1];
    battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
}



}


