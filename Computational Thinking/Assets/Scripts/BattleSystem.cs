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
    public RectTransform enemyBattleStation;
    public GameObject enemyPrefab;
    public GameObject enemyGO;
    public string sentence;


    public bool battleOver;

    



    // Start is called before the first frame update
    public void Start()
    {
        battleOver = false;
        enemyUnit = enemyCards[index];
        enemyPrefab.GetComponent<CardDisplay>().card = enemyUnit;
        enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
        enemyGO.GetComponent<RectTransform>().anchoredPosition = enemyBattleStation.GetComponent<RectTransform>().anchoredPosition;
        enemyHUD = enemyGO.GetComponent<CardDisplay>();
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
            Debug.Log("BATALHA COME~ÇA");
            yield return new WaitForSeconds(2f);
            Debug.Log("BATALHA COMEcou");
            StartCoroutine(PlayerAttack());
        }
	}

	IEnumerator PlayerAttack()
	{
	    bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        Instantiate(playerUnit.attack,playerGO.GetComponent<CardDisplay>().attackPoint.position,Quaternion.identity);
        enemyHUD.SetHP(enemyUnit.currentHP);
       
        //dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f);

		if(isDead)
		{
            index--;
            if(index < 0)
            {
                battleOver = true;
            }
            enemyGO.GetComponent<Damage>().StartCoroutine(enemyGO.GetComponent<Damage>().DeathCoroutine(2.7f));
            enemyUnit = enemyCards[index];
            enemyPrefab.GetComponent<CardDisplay>().card = enemyUnit;
            enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
            enemyGO.GetComponent<RectTransform>().anchoredPosition = enemyBattleStation.GetComponent<RectTransform>().anchoredPosition;
            enemyHUD = enemyGO.GetComponent<CardDisplay>();
            EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
           
        }
	}

    IEnumerator EnemyTurn()
    {
        //dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            playerGO.GetComponent<Damage>().StartCoroutine(enemyGO.GetComponent<Damage>().DeathCoroutine(2.7f));
            {
                EndBattle();
            }
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
