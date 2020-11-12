﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleStateFin { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystemFin : MonoBehaviour
{
    public Tarefa04 tarefaManager;
    public Canvas cardCanvas; 
    public DialogueManager manager;

    public int numberAttacks = 0;
    public bool isDead;

    public Card playerUnit;
    public Card enemyUnit;
    public PlayerStats playerStats;
    public EnemyStats enemyStats;

    public Text dialogueText;

    CardDisplay playerHUD;
    CardDisplay enemyHUD;

    public BattleState state;

    public GameObject playerGO;

    public int index;
    public int playerIndex;

    public Card[] enemyCards;
    public GameObject[] playerCards;
    public RectTransform enemyBattleStation;
    public GameObject enemyPrefab;
    public GameObject enemyGO;
    public string sentence;

    public bool battleOver;
    public bool battleWon;


    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public Transform attackPoint4;


    public int calculo;
    public int resultado;
    public GameObject input;
    public Text healthText;
    public GameObject attackButton;



    // Start is called before the first frame update

    public void SetBattle()
    {
        battleWon = false;
        enemyUnit = enemyCards[index];
        enemyPrefab.GetComponent<CardDisplay>().card = enemyUnit;
        enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
        enemyGO.GetComponent<RectTransform>().anchoredPosition = enemyBattleStation.GetComponent<RectTransform>().anchoredPosition;
        enemyGO.GetComponent<EnemyStats>().card = enemyUnit;
        enemyStats = enemyGO.GetComponent<EnemyStats>();
        enemyStats.SetStats();
        enemyHUD = enemyGO.GetComponent<CardDisplay>();
        enemyUnit.currentHP = enemyUnit.maxHP;
    }
    public void StartBattle()
    {
        if (playerGO == null)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você precisa escolher uma carta!";
            StartCoroutine(Wait2Dialogue());
        }
        else
        {
            attackButton.SetActive(false);
            playerUnit = playerGO.GetComponent<CardDisplay>().card;
            playerHUD = playerGO.GetComponent<CardDisplay>();
            playerStats = playerGO.GetComponent<PlayerStats>();


            for (int i = 0; i <= playerUnit.forte.Length - 1 && numberAttacks == 0; i++)
            {
                if (playerUnit.forte[i].Equals(enemyUnit.tipo))
                {
                    numberAttacks = 3;
                }
            }
            for (int i = 0; i <= playerUnit.empate.Length - 1 && numberAttacks == 0; i++)
            {

                if (playerUnit.empate[i].Equals(enemyUnit.tipo))
                {
                    numberAttacks = 2;
                }
            }
            for (int i = 0; i <= playerUnit.fraquezas.Length - 1 && numberAttacks == 0; i++)
            {

                if (playerUnit.fraquezas[i].Equals(enemyUnit.tipo))
                {

                    numberAttacks = 1;
                }
            }
            playerGO.GetComponent<DragDrop>().enabled = false;
            input.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Agora você precisa adivinhar qual será o valor da vida do inimigo após esse ataque! Será que vai esgotar os pontos de vida do oponente? ";
            resultado = enemyStats.currentHealth - playerUnit.damage * numberAttacks;
            if (resultado <= 0)
            {
                resultado = 0;
            }
            if (numberAttacks == 1)
            {
                healthText.text = enemyStats.currentHealth.ToString() + " - " + playerUnit.damage.ToString() + " ->";
            }
            else
            {
                healthText.text = enemyStats.currentHealth.ToString() + " - (" + numberAttacks.ToString() + " X " + playerUnit.damage.ToString() + ") ->";
            }
        }
    }

        IEnumerator PlayerAttack()
        {
            input.SetActive(false);
            if (numberAttacks == 3)
            {
                isDead = enemyStats.TakeDamage(3 * playerUnit.damage);
               ParticleSystem go=  Instantiate(playerUnit.attack, attackPoint.position, Quaternion.identity);
            ParticleSystem go2 = Instantiate(playerUnit.attack, attackPoint2.position, Quaternion.identity);
            ParticleSystem go3 = Instantiate(playerUnit.attack, attackPoint3.position, Quaternion.identity);
            Destroy(go.gameObject, 5f);
            Destroy(go2.gameObject, 5f);
            Destroy(go3.gameObject, 5f);

        }
            if (numberAttacks == 2)
            {
                isDead = enemyStats.TakeDamage(2 * playerUnit.damage);
            ParticleSystem go = Instantiate(playerUnit.attack, attackPoint.position, Quaternion.identity);
            ParticleSystem go2 = Instantiate(playerUnit.attack, attackPoint2.position, Quaternion.identity);
            Destroy(go.gameObject, 5f);
            Destroy(go2.gameObject, 5f);
        }
            if (numberAttacks == 1)
            {
                isDead = enemyStats.TakeDamage(playerUnit.damage);
            ParticleSystem go = Instantiate(playerUnit.attack, attackPoint.position, Quaternion.identity);
            Destroy(go.gameObject, 5f);
            }         
            yield return new WaitForSeconds(1f);
            numberAttacks = 0;
            if (isDead)
            {
                index--;
                if (index < 0)
                {
                    enemyGO.GetComponent<CardDamage>().StartCoroutine(enemyGO.GetComponent<CardDamage>().DeathCoroutine(1.5f));
                    yield return new WaitForSeconds(5f);
                    battleOver = true;
                    battleWon = true;
                    enemyHUD.SetHP(0);
                    state = BattleState.START;
                    playerGO.GetComponent<DragDrop>().enabled = true;
                    tarefaManager.BattleEnd();
                }
                else
                {
                    enemyHUD.SetHP(0);
                    enemyGO.GetComponent<CardDamage>().StartCoroutine(enemyGO.GetComponent<CardDamage>().DeathCoroutine(1.5f));
                    yield return new WaitForSeconds(5f);
                    enemyUnit = enemyCards[index];
                    enemyPrefab.GetComponent<CardDisplay>().card = enemyUnit;
                    enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
                    enemyGO.GetComponent<RectTransform>().anchoredPosition = enemyBattleStation.GetComponent<RectTransform>().anchoredPosition;
                    enemyStats = enemyGO.GetComponent<EnemyStats>();
                    enemyGO.GetComponent<EnemyStats>().card = enemyUnit;
                    enemyStats.SetStats();
                    enemyHUD = enemyGO.GetComponent<CardDisplay>();
                    enemyUnit.currentHP = enemyUnit.maxHP;
                    EndBattle();
                }
            }
            else
            {
                enemyHUD.SetHP(enemyStats.currentHealth);
                enemyGO.GetComponent<CardDamage>().StartCoroutine(enemyGO.GetComponent<CardDamage>().DamageCoroutine(0f, 5, 0.5f));
                yield return new WaitForSeconds(3f);
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());

            }
        }

        IEnumerator EnemyTurn()
        {
            //dialogueText.text = enemyUnit.unitName + " attacks!";

            yield return new WaitForSeconds(1f);
            for (int i = 0; i <= enemyUnit.forte.Length - 1 && numberAttacks == 0; i++)
            {
                if (enemyUnit.forte[i].Equals(playerUnit.tipo))
                {
                    numberAttacks = 3;
                }
            }
            for (int i = 0; i <= enemyUnit.empate.Length - 1 && numberAttacks == 0; i++)
            {

                if (enemyUnit.empate[i].Equals(playerUnit.tipo))
                {
                    numberAttacks = 2;
                }
            }
            for (int i = 0; i <= enemyUnit.fraquezas.Length - 1 && numberAttacks == 0; i++)
            {

                if (enemyUnit.fraquezas[i].Equals(playerUnit.tipo))
                {
                    numberAttacks = 1;
                }
            }
            if (numberAttacks == 3)
            {
                isDead = playerStats.TakeDamage(3 * enemyUnit.damage);
            ParticleSystem go = Instantiate(enemyUnit.attack, attackPoint.position, Quaternion.identity);
            ParticleSystem go2 = Instantiate(enemyUnit.attack, attackPoint2.position, Quaternion.identity);
            ParticleSystem go3 = Instantiate(enemyUnit.attack, attackPoint3.position, Quaternion.identity);
            Destroy(go.gameObject, 5f);
            Destroy(go2.gameObject, 5f);
            Destroy(go3.gameObject, 5f);

        }
            if (numberAttacks == 2)
            {
                numberAttacks = 2;
                isDead = playerStats.TakeDamage(2 * enemyUnit.damage);
            ParticleSystem go = Instantiate(enemyUnit.attack, attackPoint.position, Quaternion.identity);
            ParticleSystem go2 = Instantiate(enemyUnit.attack, attackPoint2.position, Quaternion.identity);
            Destroy(go.gameObject, 5f);
            Destroy(go2.gameObject, 5f);
        }
            if (numberAttacks == 1)
            {
                isDead = playerStats.TakeDamage(enemyUnit.damage);
            ParticleSystem go = Instantiate(enemyUnit.attack, attackPoint.position, Quaternion.identity);
            Destroy(go.gameObject, 5f);

        }
            numberAttacks = 0;

            if (isDead)
            {
                playerIndex--;
                playerGO.GetComponent<CardDamage>().StartCoroutine(playerGO.GetComponent<CardDamage>().DeathCoroutine(1.5f));
                playerHUD.SetHP(0);
                if (playerIndex < 0)
                {
                    yield return new WaitForSeconds(5f);
                    battleOver = true;
                    battleWon = false;
                    state = BattleState.START;
                    playerGO.GetComponent<DragDrop>().enabled = true;
                    tarefaManager.BattleEnd();

                }
                else
                {
                EndBattle();
                }
            }
            else
            {
                playerHUD.SetHP(playerStats.currentHealth);
                playerGO.GetComponent<CardDamage>().StartCoroutine(playerGO.GetComponent<CardDamage>().DamageCoroutine(0f, 5, 0.5f));
                yield return new WaitForSeconds(3f);
                EndBattle();
            }
        }

        void EndBattle()
        {
            state = BattleState.START;
            playerGO.GetComponent<DragDrop>().enabled = true;
            attackButton.SetActive(true);
        }

        public IEnumerator Wait2Dialogue()
        {
            yield return new WaitForSeconds(3f);
            manager.GetComponent<DialogueManager>().DialogueText.text = sentence;

        }

        public void GetInput(string guess)
        {
            if (guess == "")
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "Você precisa escrever um resultado!";
                StartCoroutine(Wait2Dialogue());
            }
            else
            {
                calculo = int.Parse(guess);
                if (calculo == resultado)
                {
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
                    StartCoroutine(PlayerAttack());
                }
                else
                {
                    sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
                    StartCoroutine(Wait2Dialogue());
                }
            }
        }
    }
      

