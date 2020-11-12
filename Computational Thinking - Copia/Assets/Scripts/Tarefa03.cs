using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tarefa03 : MonoBehaviour
{
    Card playerUnit;
    Card enemyUnit;
    CardDisplay playerHUD;
    CardDisplay enemyHUD;

    public GameObject input;
    public Text inputText;

    public CanvasEffects Canvas;
    public DialogueManager manager;

    public int count;
  
    float nextSentenceTime = 0f;
    public float sentenceRate;
    public RectTransform cardShow;
    public GameObject opponent1;
    public GameObject opponent2;
    public GameObject card;
    public GameObject card2;
    public Transform attackPoint;
    public GameObject fire;
    public GameObject water;
    public GameObject plant;
    public GameObject battleSystem;
    public GameObject[] playerCards;
    public GameObject attackButton;
    public GameObject nextButton;
    public GameObject enemyCardPos;
    public Transform professorBattle;
    public GameObject professor;
    string sentence;
    public bool isQuestion;
    public int calculo;
    public int resultado;
    public GameObject lifePointer;
    public Transform attackPointer;
    public Transform elementPointer;
    public Transform damagePointer;
    public PlayerStats playerStats;
    public EnemyStats enemyStats;


    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 24;
        enemyStats.SetStats();
    }
    public void Update()
    {
        if (Time.time >= nextSentenceTime && isQuestion == false)
        {
            nextButton.SetActive(true);
        }    
    }


    public void NextSceneScript()
    {
       
        nextSentenceTime = Time.time + 1f / sentenceRate;
        nextButton.SetActive(false);
        count--;
        if (count == 1)
        {
            isQuestion = true;
        }
        if (count == 3)
            {
                battleSystem.SetActive(true);
                battleSystem.GetComponent<BattleSystem>().SetBattle();
                playerCards[0].SetActive(true);
                playerCards[1].SetActive(true);
                playerCards[2].SetActive(true);
                playerCards[3].SetActive(true);
                playerCards[4].SetActive(true);
                playerCards[5].SetActive(true);
                attackButton.SetActive(true);
                nextButton.SetActive(false);
                opponent1.SetActive(true);
                enemyCardPos.SetActive(true);
                isQuestion = true;
           

            }
            if(count == 4)
            {
                plant.SetActive(false);
            }
            if (count == 5)
            {
                plant.SetActive(true);
                water.SetActive(false);
                plant.transform.position = attackPoint.position;
            }
            if (count == 6)
            {
                fire.SetActive(false);
                water.SetActive(true);
                water.transform.position = attackPoint.position;
            }
            if (count == 7)
            {
                fire.SetActive(true);
                fire.transform.position = attackPoint.position;
            }
            if (count == 12)
            {
                opponent1.SetActive(false);
                opponent2.SetActive(false);
                card.SetActive(false);
            }
        if (count == 14)
        {
            StartCoroutine(ElementalAttack2());
            StartCoroutine(ElementalAttack2Damage());
            isQuestion = false;
            input.SetActive(false);
        }
        if (count == 15)
        {
            StartCoroutine(ElementalAttack2Damage());
            isQuestion = false;
            input.SetActive(false);
        }
        if (count == 16)
        {
            input.SetActive(true);
            inputText.text = "10 - 5 ->";
            nextButton.SetActive(false);
            resultado = 5;
            isQuestion = true;
        }
        if (count == 17)
            {
                StartCoroutine(ElementalAttack2());
            }

            if (count == 19)
            {
            lifePointer.SetActive(false);
            opponent1.SetActive(true);
                opponent2.SetActive(true);
                card.GetComponent<RectTransform>().anchoredPosition = opponent1.GetComponent<RectTransform>().anchoredPosition;
                card2.SetActive(true);
                card2.GetComponent<RectTransform>().anchoredPosition = opponent2.GetComponent<RectTransform>().anchoredPosition;
                playerUnit = card.GetComponent<CardDisplay>().card;
                enemyUnit = card2.GetComponent<CardDisplay>().card;
                enemyUnit.currentHP = enemyUnit.maxHP;
                enemyHUD = card2.GetComponent<CardDisplay>();
                playerHUD = card.GetComponent<CardDisplay>();
                professor.transform.position = professorBattle.position;

        }
        if (count == 20)
        {
            lifePointer.GetComponent<RectTransform>().anchoredPosition = attackPointer.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 21)
        {
            lifePointer.SetActive(true);
        }
        if (count == 22)
            {
                card.SetActive(true);
                card.GetComponent<RectTransform>().anchoredPosition = cardShow.GetComponent<RectTransform>().anchoredPosition;
            }
            if (count == 23)
            {
            Canvas.Fade();
            }
        }
     public IEnumerator ElementalAttack2Damage()
     {
        yield return new WaitForSeconds(1f);
        bool isDead = enemyStats.TakeDamage(5);
        enemyHUD.SetHP(enemyStats.currentHealth);
        if (isDead)
         {
             card2.GetComponent<CardDamage>().StartCoroutine(card2.GetComponent<CardDamage>().DeathCoroutine(1.5f));
             enemyHUD.SetHP(0);
         }
         else
         {
             card2.GetComponent<CardDamage>().StartCoroutine(card2.GetComponent<CardDamage>().DamageCoroutine(0f, 5, 0.5f));

         }
     }
    public IEnumerator ElementalAttack2()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(playerUnit.attack, attackPoint.position, Quaternion.identity);
    }
    public IEnumerator ParticleCoroutine(ParticleSystem particle, Transform particlePosition)
    {
        yield return new WaitForSeconds(1.4f);
        ParticleSystem go = Instantiate(particle, particlePosition.position, Quaternion.identity);
        Destroy(go.gameObject, 1.5f);
    }
    public IEnumerator WaitDialogue()
    {
        yield return new WaitForSeconds(1f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
    }
    public void GetInput(string guess)
    {
        if (guess == "")
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você precisa escrever um resultado!";
            StartCoroutine(Wait2DialogueDrag());
        }
        else
        {
            calculo = int.Parse(guess);
            if(calculo == resultado)
            {
                manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
                StartCoroutine(WaitDialogueDrag());
            }
            else
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
                StartCoroutine(Wait2DialogueDrag());
            }
        }
        
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
    public void BattleEnd()
    {
        nextButton.SetActive(false);
        attackButton.SetActive(false);
        playerCards[0].SetActive(false);
        playerCards[1].SetActive(false);
        playerCards[2].SetActive(false);
        playerCards[3].SetActive(false);
        playerCards[4].SetActive(false);
        playerCards[5].SetActive(false);
        attackButton.SetActive(false);
        opponent1.SetActive(false);
        enemyCardPos.SetActive(false);
        isQuestion = false;
        if (battleSystem.GetComponent<BattleSystem>().battleWon == true)
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Wow! Você me derrotou dessa vez!";
        }
        else
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Parece que você perdeu dessa vez, mas foi uma boa batalha!";
        }

    }

}

