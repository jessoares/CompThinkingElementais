using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tarefa04 : MonoBehaviour
{
    public Canvas cardCanvas;
    public RectTransform enemyBattleStation;
    public GameObject enemyPrefab;
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
    public Transform attackPoint1;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public GameObject lifePointer;
    public Transform attackPointer;
    public Transform elementPointer;
    public Transform damagePointer;
    public GameObject fire;
    public GameObject water;
    public GameObject plant;
    public GameObject firel;
    public GameObject waterl;
    public GameObject plantl;
    public GameObject battleSystem;
    public GameObject[] playerCards;
    public GameObject attackButton;
    public GameObject nextButton;
    public GameObject enemyCardPos;
    public GameObject perdedores;
    public GameObject ganhadores;
    public GameObject raio;
    public GameObject pedra;
    public Card tocha;
    public Card Marinho;
    public Card Carnivora;
    string sentence;
    public bool isQuestion;
    public int calculo;
    public int resultado;
    public Sprite rochoso;
    public Sprite trovoada;
    public Sprite torrao;
    public Sprite eletron;
    public Sprite pedraSprite;
    public Sprite raioSprite;

    public GameObject elemental;


    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 55;


    }
    public void Update()
    {
        if (Time.time >= nextSentenceTime && isQuestion == false)
        {
            nextButton.SetActive(true);
        }
        if (battleSystem.GetComponent<BattleSystem>().battleOver && battleSystem.GetComponent<BattleSystem>().battleWon == false)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Ufa essa foi por pouco!, mas você já dominou os básicos de combate!";
            StartCoroutine(WaitDialogue());
        }
        if (battleSystem.GetComponent<BattleSystem>().battleOver && battleSystem.GetComponent<BattleSystem>().battleWon == true)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Parabéns, voce derrotou meu time.";
            StartCoroutine(WaitDialogue());
        }
    }


    public void NextSceneScript()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        nextButton.SetActive(false);
        count--;

        if (count == 3)
        {

            battleSystem.SetActive(false);
            playerCards[0].SetActive(false);
            playerCards[1].SetActive(false);
            playerCards[2].SetActive(false);
            playerCards[3].SetActive(false);
            playerCards[4].SetActive(false);
            playerCards[5].SetActive(false);
            attackButton.SetActive(false);
            opponent1.SetActive(false);
            enemyCardPos.SetActive(false);
            nextButton.SetActive(true);

        }
        if (count == 4)
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
            isQuestion = true;


        }
        if (count == 5)
        {
            elemental.GetComponent<SpriteRenderer>().sprite = trovoada;
        }
        if (count == 5)
        {
            elemental.SetActive(false);
            raio.transform.position = water.transform.position;
            firel.SetActive(true);
            StartCoroutine(AttackCoroutine(raio, firel.transform));           
            firel.GetComponent<Damage>().StartCoroutine(firel.GetComponent<Damage>().DeathCoroutine(1.5f));
          
        }
        if (count == 5)
        {
            elemental.GetComponent<SpriteRenderer>().sprite = trovoada;
        }
        if (count == 5)
        {
            elemental.SetActive(true);
            elemental.GetComponent<SpriteRenderer>().sprite = eletron;
        }
    
        if (count == 6)
        {
            elemental.SetActive(false);
        }
        if (count == 7)
        {
            elemental.GetComponent<SpriteRenderer>().sprite = torrao;
        }
        if (count == 8)
        {
            elemental.GetComponent<SpriteRenderer>().sprite = rochoso;
        }
        if (count == 28)
        {
            raio.SetActive(false);
            pedra.SetActive(false);

        }
        if (count == 30)
        {
            opponent1.SetActive(false);
            opponent2.SetActive(false);
            card.SetActive(false);

        }
        if (count == 32)
        {
            //StartCoroutine(ElementalAttack2());
        }
        if (count == 33)
        {
            card2.GetComponent<CardDisplay>().card = tocha;
            card2 = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
        }
        if (count == 34)
        {
           // StartCoroutine(ElementalAttack());
        }
        if (count == 35)
        {
            card2.GetComponent<CardDisplay>().card = Marinho;
            card2 = Instantiate(enemyPrefab, enemyBattleStation.position, Quaternion.identity, cardCanvas.transform);
        }
        if (count == 38)
        {
            //StartCoroutine(ElementalAttack3());
        }
        if (count == 39)
        {
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
            card.SetActive(true);
        }
        if (count == 40)
        {
            ganhadores.SetActive(false);
            perdedores.SetActive(false);
        }

        if (count == 41)
        {
            StartCoroutine(AttackCoroutine(water, firel.transform));
            StartCoroutine(AttackCoroutine(fire, plantl.transform));
            StartCoroutine(AttackCoroutine(plant, waterl.transform));
            firel.GetComponent<Damage>().StartCoroutine(firel.GetComponent<Damage>().DeathCoroutine(1.5f));
            waterl.GetComponent<Damage>().StartCoroutine(waterl.GetComponent<Damage>().DeathCoroutine(1.5f));
            plantl.GetComponent<Damage>().StartCoroutine(plantl.GetComponent<Damage>().DeathCoroutine(1.5f));
        }
        if (count == 42)
        {
            ganhadores.SetActive(true);
            perdedores.SetActive(true);
            opponent1.SetActive(false);
            opponent2.SetActive(false);
            card2.SetActive(false);
            card.SetActive(false);
        }

        if (count == 45)
        {
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
           // StartCoroutine(ElementalAttack());


        }
        if (count == 46)
        {
            lifePointer.SetActive(false);
        }
        if (count == 47)
        {
            lifePointer.GetComponent<RectTransform>().Rotate(new Vector3(0,0,-180));
            lifePointer.GetComponent<RectTransform>().anchoredPosition = damagePointer.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 48)
        {
            lifePointer.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            lifePointer.GetComponent<RectTransform>().anchoredPosition = elementPointer.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 49)
        {
            lifePointer.GetComponent<RectTransform>().anchoredPosition = attackPointer.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 50)
            {

                lifePointer.SetActive(true);
            }
            if (count == 51)
            {
                card.SetActive(true);
                lifePointer.SetActive(false);
                card.GetComponent<RectTransform>().anchoredPosition = cardShow.GetComponent<RectTransform>().anchoredPosition;
            }
            if (count == 54)
            {
            Canvas.Fade();


        }

        
    }





    public IEnumerator AttackCoroutine(GameObject elemental, Transform target)
    {
        yield return new WaitForSeconds(1f);
        elemental.GetComponent<Movement>().attackPoint = target;
        elemental.GetComponent<Movement>().state = Movement.State.Attack;
    }

   /* public IEnumerator ElementalAttack()
    {
        yield return new WaitForSeconds(1f);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        Instantiate(playerUnit.attack, attackPoint1.position, Quaternion.identity);
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
    public IEnumerator ElementalAttack2()
    {
        yield return new WaitForSeconds(1f);
        //bool isDead = enemyUnit.TakeDamage(playerUnit.damage * 2);
        Instantiate(playerUnit.attack, attackPoint1.position, Quaternion.identity);
        Instantiate(playerUnit.attack, attackPoint2.position, Quaternion.identity);
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
    
    public IEnumerator ElementalAttack3()
    {
        yield return new WaitForSeconds(1f);
        //bool isDead = enemyUnit.TakeDamage(playerUnit.damage * 3);
        Instantiate(playerUnit.attack, attackPoint1.position, Quaternion.identity);
        Instantiate(playerUnit.attack, attackPoint2.position, Quaternion.identity);
        Instantiate(playerUnit.attack, attackPoint3.position, Quaternion.identity);
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

    public void ElementalAttackDamage()
    {
        //bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
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

    */
    public IEnumerator ElementalAttack4()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(playerUnit.attack, attackPoint1.position, Quaternion.identity);

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
            if (calculo == resultado)
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
}

