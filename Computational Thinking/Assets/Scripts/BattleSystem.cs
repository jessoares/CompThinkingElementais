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
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{    
        if (playerGO == null)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você precisa escolher uma carta!";
            StartCoroutine(Wait2Dialogue());
        }
        else
        {
            playerUnit = playerGO.GetComponent<CardDisplay>().card;
            playerHUD = playerGO.GetComponent<CardDisplay>();
            yield return new WaitForSeconds(1f);
            StartCoroutine(PlayerAttack());
        }
	}

	IEnumerator PlayerAttack()
	{
	    bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        Instantiate(playerUnit.attack,attackPoint.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
		if(isDead)
		{
            index--;
            if(index < 0)
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
		} else
		{
            enemyHUD.SetHP(enemyUnit.currentHP);
            enemyGO.GetComponent<CardDamage>().StartCoroutine(enemyGO.GetComponent<CardDamage>().DamageCoroutine(0f,5,0.5f));
            yield return new WaitForSeconds(3f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
           
        }
	}

    IEnumerator EnemyTurn()
    {
        //dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

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
	}
	
    public IEnumerator Wait2Dialogue()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;

    }


}
