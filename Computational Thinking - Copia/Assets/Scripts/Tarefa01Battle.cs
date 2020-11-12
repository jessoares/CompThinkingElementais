using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStateTarefa01 { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class Tarefa01Battle : MonoBehaviour
{
    public Tarefa01 tarefaManager;
    public Canvas cardCanvas; //for enemy card transform
    public DialogueManager manager;

    public Elemental playerUnit;
    public Elemental enemyUnit;
    public Elemental randomUnit;
    public Text dialogueText;

    public GameObject playerGO;
    public int randomEle;
    public int index;
    public int playerIndex;

    public Elemental[] enemyCards;
    public GameObject[] playerCards;
    public RectTransform enemyBattleStation;
    public GameObject enemyPrefab;
    public GameObject enemyGO;
    public string sentence;

    public bool battleOver;
    public bool battleWon;
    public Transform attackPoint;

    public GameObject attackButton;

    string tipo;

    public void SetBattle()
    {             
           if (playerGO == null)
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "Você precisa escolher um elemental!";
                StartCoroutine(Wait2Dialogue());
            }
            else
            {
            while (randomUnit == null)
            {
                randomEle = Random.Range(0, 6);
                randomUnit = enemyCards[randomEle];
            }
            randomUnit = null;
            enemyUnit = enemyCards[randomEle];
            enemyPrefab.GetComponent<Tarefa01Display>().card = enemyUnit;
            enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
            enemyGO.GetComponent<RectTransform>().anchoredPosition = enemyBattleStation.GetComponent<RectTransform>().anchoredPosition;
            StartCoroutine(StartBattle());
            }

        
    }

    public IEnumerator StartBattle()
    {
        playerGO.GetComponent<DragDrop>().enabled = false;
        Debug.Log("BATTLE START");
        playerUnit = playerGO.GetComponent<Tarefa01Display>().card;
        attackButton.SetActive(false);
        if (playerUnit.forte.Equals(enemyUnit.tipo))
        {
            Instantiate(playerUnit.attack, attackPoint.position, Quaternion.identity);
            enemyGO.GetComponent<CardDamage>().StartCoroutine(enemyGO.GetComponent<CardDamage>().DeathCoroutine(1.5f));
            yield return new WaitForSeconds(1.5f);
            if (playerUnit.tipo.Equals("Fogo"))
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "Seu Tocha venceu! As chamas são destrutivas contra plantas!";
                StartCoroutine(Wait2Dialogue());
            }
            else if (playerUnit.tipo.Equals("Agua"))
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "Seu Marinho venceu! Chamas não resistem à água!";
                StartCoroutine(Wait2Dialogue());
            }
            else if (playerUnit.tipo.Equals("Planta"))
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "Seu Carnívora venceu! Plantas absorvem água facilmente!";
                StartCoroutine(Wait2Dialogue());
            }
            enemyCards[randomEle] = null;
            index--;
            if (index >= 0)
            {
                yield return new WaitForSeconds(3f);
                EndBattle();
            }
            else
            {
                yield return new WaitForSeconds(3f);
                battleWon = true;
                tarefaManager.BattleEnd();

            }
        }
        else if (enemyUnit.forte.Equals(playerUnit.tipo))
        {
            Instantiate(enemyUnit.attack, attackPoint.position, Quaternion.identity);
            playerGO.GetComponent<CardDamage>().StartCoroutine(playerGO.GetComponent<CardDamage>().DeathCoroutine(1.5f));
            if (enemyUnit.tipo.Equals("Fogo"))
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "O meu Tocha venceu! As chamas são destrutivas contra plantas!";
                StartCoroutine(Wait2Dialogue());
            }
            else if (enemyUnit.tipo.Equals("Agua"))
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "O meu Marinho venceu! Chamas não resistem à água!";
                StartCoroutine(Wait2Dialogue());
            }
            else if (enemyUnit.tipo.Equals("Planta"))
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "O meu Carnívora venceu! Plantas absorvem água facilmente!";
                StartCoroutine(Wait2Dialogue());
            }
            playerIndex--;
            if (playerIndex < 0)
            {
                yield return new WaitForSeconds(3f);

                battleWon = false;
                tarefaManager.BattleEnd();
            }
            else
            {
                yield return new WaitForSeconds(3f);
                EndBattle();
            }

        }
        else if (enemyUnit.tipo.Equals(playerUnit.tipo))
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Opa! Esses elementais são do mesmo elemento, então essa rodada é um empate!";
            StartCoroutine(Wait2Dialogue());
            yield return new WaitForSeconds(3f);
            EndBattle();
           
        }
            
    }

    void EndBattle()
    {
        playerGO.GetComponent<DragDrop>().enabled = true;
        Destroy(enemyGO);
        attackButton.SetActive(true);

    }
    public IEnumerator Wait2Dialogue()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;
    }
}

 


