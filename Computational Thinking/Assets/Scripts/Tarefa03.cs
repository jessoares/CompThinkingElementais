using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tarefa03 : MonoBehaviour
{
    Card playerUnit;
    Card enemyUnit;
    CardDisplay playerHUD;
    CardDisplay enemyHUD;

    public CanvasEffects Canvas;
    public DialogueManager manager;
    
    public int count = 30;
  
    float nextSentenceTime = 0f;
    public float sentenceRate;
    public RectTransform cardShow;
    public GameObject opponent1;
    public GameObject opponent2;
    public GameObject card;
    public GameObject card2;
    public GameObject pointers;
    public Transform attackPoint;
    public GameObject fire;
    public GameObject water;
    public GameObject plant;
    public GameObject battleSystem;
    public GameObject[] playerCards;
    public GameObject attackButton;
    public GameObject nextButton;
    public GameObject enemyCardPos;
    string sentence;


    public void NextSceneScript()
    {
        if(battleSystem.GetComponent<BattleSystem>().battleOver && battleSystem.GetComponent<BattleSystem>().battleWon == false)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Essa foi por pouco!, acho que você já dominou o básico do combate!";
            StartCoroutine(WaitDialogue());
        }
       

        if (Time.time >= nextSentenceTime)
        {
            count--;
            nextSentenceTime = Time.time + 1f / sentenceRate;
            if (count == 11)
            {

                nextButton.SetActive(false);

            }
            if (count == 12)
            {
                battleSystem.SetActive(true);
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


            }
            if(count == 13)
            {
                plant.SetActive(false);
            }
            if (count == 14)
            {
                plant.SetActive(true);
                water.SetActive(false);
                plant.transform.position = attackPoint.position;
            }
            if (count == 15)
            {
                fire.SetActive(false);
                water.SetActive(true);
                water.transform.position = attackPoint.position;
            }
            if (count == 16)
            {
                fire.SetActive(true);
                fire.transform.position = attackPoint.position;
            }
            if (count == 21)
            {
                opponent1.SetActive(false);
                opponent2.SetActive(false);
                card.SetActive(false);
            }
            if (count == 23)
            {           
                StartCoroutine(ElementalAttack());
            }
            if (count == 25)
            {
                StartCoroutine(ElementalAttack());
            }

            if (count == 26)
            {
                opponent1.SetActive(true);
                opponent2.SetActive(true);
                pointers.SetActive(false);
                card.GetComponent<RectTransform>().anchoredPosition = opponent1.GetComponent<RectTransform>().anchoredPosition;
                card2.SetActive(true);
                card2.GetComponent<RectTransform>().anchoredPosition = opponent2.GetComponent<RectTransform>().anchoredPosition;
                playerUnit = card.GetComponent<CardDisplay>().card;
                enemyUnit = card2.GetComponent<CardDisplay>().card;
                enemyUnit.currentHP = enemyUnit.maxHP;
                enemyHUD = card2.GetComponent<CardDisplay>();
                playerHUD = card.GetComponent<CardDisplay>();
            }
          
            if (count == 27)
            {
                pointers.SetActive(true);
            }
            if (count == 28)
            {
 
                card.SetActive(true);
                card.GetComponent<RectTransform>().anchoredPosition = cardShow.GetComponent<RectTransform>().anchoredPosition;
            }
            if (count == 29)
            {

                Canvas.Fade();
            }

        }
    }
   
    public IEnumerator AttackCoroutine(GameObject elemental, Transform target)
    {
        yield return new WaitForSeconds(2.7f);
        elemental.GetComponent<Movement>().attackPoint = target;
        elemental.GetComponent<Movement>().state = Movement.State.Attack;
    }

    public IEnumerator ElementalAttack()
    {
        yield return new WaitForSeconds(1f);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        Instantiate(playerUnit.attack, attackPoint.position, Quaternion.identity);
        enemyHUD.SetHP(enemyUnit.currentHP);
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

    public IEnumerator ParticleCoroutine(ParticleSystem particle, Transform particlePosition)
    {
        yield return new WaitForSeconds(1.4f);
        Instantiate(particle, particlePosition.position, Quaternion.identity);
    }
    public IEnumerator WaitDialogue()
    {
        yield return new WaitForSeconds(1f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
    }
    
}
