using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public Canvas cardCanvas; //for enemy card transform
    public DialogueManager manager;

    Card playerUnit;
    Card enemyUnit;
    EnemyStats enemyStats;
    PlayerStats playerStats;

    public Text dialogueText;

    CardDisplay playerHUD;
    CardDisplay enemyHUD;

    public BattleState state;

    public GameObject playerGO;

    public int index;

    public Card[] enemyCards;
    public GameObject[] playerCards;
    public RectTransform enemyBattleStation;
    public GameObject enemyPrefab;
    public GameObject enemyGO;
    public string sentence;

    public bool battleOver;
    public bool battleWon;


    public Transform attackPoint;


   public  int calculo;
   public  int resultado;
    public GameObject input;
    public Text healthText;
    public Text attackText;


    // Start is called before the first frame update
    public void Start()
    {
        battleOver = false;
        enemyUnit = enemyCards[index];
        enemyPrefab.GetComponent<CardDisplay>().card = enemyUnit;
        enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
        enemyGO.GetComponent<RectTransform>().anchoredPosition = enemyBattleStation.GetComponent<RectTransform>().anchoredPosition;
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
            input.SetActive(true);
            playerUnit = playerGO.GetComponent<CardDisplay>().card;
            playerHUD = playerGO.GetComponent<CardDisplay>();
            resultado = enemyUnit.currentHP - playerUnit.damage;
            if (resultado <= 0)
            {
                resultado = 0;
            }
            attackText.text = playerUnit.damage.ToString();
            healthText.text = enemyUnit.currentHP.ToString();
            manager.GetComponent<DialogueManager>().DialogueText.text = "Primeiro você precisa adivinhar qual será o valor da vida do inimigo após esse ataque! Será que vai chegar a zero?";
            playerGO.GetComponent<DragDrop>().enabled = false;
        }


    }



    IEnumerator PlayerAttack()
    {
        input.SetActive(false);
        bool isDead = enemyStats.TakeDamage(playerUnit.damage);
        Instantiate(playerUnit.attack, attackPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            index--;
            if (index < 0)
            {
                battleOver = true;
                battleWon = true;
            }
            enemyHUD.SetHP(0);
            Debug.Log("inimigo morreu");
            enemyGO.GetComponent<CardDamage>().StartCoroutine(enemyGO.GetComponent<CardDamage>().DeathCoroutine(1.5f));
            yield return new WaitForSeconds(5f);
            enemyUnit = enemyCards[index];
            enemyPrefab.GetComponent<CardDisplay>().card = enemyUnit;
            enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
            enemyGO.GetComponent<RectTransform>().anchoredPosition = enemyBattleStation.GetComponent<RectTransform>().anchoredPosition;
            enemyHUD = enemyGO.GetComponent<CardDisplay>();
            EndBattle();
        }
        else
        {
            enemyHUD.SetHP(enemyUnit.currentHP);
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

        bool isDead = playerStats.TakeDamage(enemyUnit.damage);

        Instantiate(enemyUnit.attack, attackPoint.position, Quaternion.identity);

        if (isDead)
        {
            playerGO.GetComponent<CardDamage>().StartCoroutine(playerGO.GetComponent<CardDamage>().DeathCoroutine(1.5f));
            playerHUD.SetHP(0);
            if (GameObject.FindGameObjectsWithTag("Card").Length == 0)
            {
                battleOver = true;
                battleWon = false;

            }
            EndBattle();
        }
        else
        {
            playerHUD.SetHP(playerUnit.currentHP);
            playerGO.GetComponent<CardDamage>().StartCoroutine(playerGO.GetComponent<CardDamage>().DamageCoroutine(0f, 5, 0.5f));
            yield return new WaitForSeconds(3f);
            EndBattle();
        }
    }

    void EndBattle()
    {
        state = BattleState.START;
        playerGO.GetComponent<DragDrop>().enabled = true;
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

