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
   public Card playerUnit;
   public Card enemyUnit;
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
     public Transform opponente1;
    public Transform opponente2;
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
    public GameObject dragon;
    public GameObject horse;
    public GameObject piranha;
    public GameObject monkey;
    public GameObject pig;
    public GameObject elemental;
    public PlayerStats playerStats;
    public EnemyStats enemyStats;
    public ParticleSystem fireParticle;
    public Transform fireParticlePosition;
    public ParticleSystem waterParticle;
    public Transform waterParticlePosition;
    public ParticleSystem plantParticle;
    public Transform plantParticlePosition;
    public ParticleSystem thunderParticle;
    public Transform thunderParticlePosition;
    public ParticleSystem rockParticle;
    public Transform rockParticlePosition;
    public Transform professorBattle;
    public GameObject professor;



    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 54;
        

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
        if (count == -1)
        {
            isQuestion = true;
        }
        if (count == 0)
        {
            battleSystem.SetActive(true);
            battleSystem.GetComponent<BattleSystemFin>().SetBattle();
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
            professor.transform.position = professorBattle.position;

        }
        if (count == 2)
        {
            card.SetActive(false);
            lifePointer.SetActive(false);       
        }
        if (count == 4)
        {
            professor.SetActive(true);
            pig.SetActive(false);
            card.SetActive(true);
            lifePointer.SetActive(true);
            card.GetComponent<RectTransform>().anchoredPosition = cardShow.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 5)
        {
            monkey.transform.rotation = new Quaternion(0, 0, 0, 0);
            pig.transform.rotation = new Quaternion(0,0, 0, 0);
            monkey.transform.position = opponente2.transform.position;
            pig.SetActive(true);
            pig.transform.position = opponente1.transform.position;
            pig.GetComponent<Movement>().attackPoint = opponente2.transform;
            pig.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(rockParticle, monkey.transform, 3f));
            monkey.GetComponent<Damage>().StartCoroutine(monkey.GetComponent<Damage>().DeathCoroutine(3.5f));
            sentenceRate = 0.7f;
        }
        if (count == 6)
        {
            horse.SetActive(true);
            piranha.SetActive(false);
            horse.transform.rotation = new Quaternion(0,0,0, 0);
            monkey.SetActive(true);
            monkey.transform.rotation = new Quaternion(0, 180, 0, 0);
            monkey.transform.position = opponente1.transform.position;
             horse.transform.position = opponente2.transform.position;
            monkey.GetComponent<Movement>().attackPoint = opponente2.transform;
            monkey.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(thunderParticle, horse.transform, 3f));
            horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(3.5f));
        }
        if (count == 8)
        {
            horse.SetActive(false);
            pig.SetActive(true);
            piranha.SetActive(true);
            piranha.transform.position = opponente1.transform.position;
            piranha.GetComponent<Movement>().attackPoint = opponente2.transform;
            piranha.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(plantParticle, pig.transform, 3f));
            pig.GetComponent<Damage>().StartCoroutine(pig.GetComponent<Damage>().DeathCoroutine(3.5f));
        }
        if (count == 9)
        {
            horse.SetActive(true);
            horse.transform.rotation = new Quaternion(0, 180, 0, 0);
            pig.transform.rotation = new Quaternion(0, 180, 0, 0);
            pig.transform.position = opponente2.transform.position;
            horse.transform.position = opponente1.transform.position;
            horse.GetComponent<Movement>().attackPoint = opponente2.transform;
            horse.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(waterParticle, pig.transform, 3f));
            pig.GetComponent<Damage>().StartCoroutine(pig.GetComponent<Damage>().DeathCoroutine(3.5f));
        }
        if(count == 10)
        {
            sentenceRate = 0.15f;
        }
        if (count == 11)
        {
            elemental.SetActive(false);
            pig.transform.position = opponente1.transform.position;
            monkey.SetActive(true);
            monkey.transform.position = opponente2.transform.position;
            pig.GetComponent<Movement>().attackPoint = opponente2.transform;
            pig.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(rockParticle, monkey.transform, 3f));
            monkey.GetComponent<Damage>().StartCoroutine(monkey.GetComponent<Damage>().DeathCoroutine(3.5f));
            sentenceRate = 0.7f;

        }
        if (count == 12)
        {
            elemental.SetActive(false);
            pig.SetActive(true);
            pig.transform.position = opponente1.transform.position;
            dragon.SetActive(true);
            dragon.transform.position = opponente2.transform.position;
            pig.GetComponent<Movement>().attackPoint = opponente2.transform;
            pig.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(rockParticle, dragon.transform, 3f));
            dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(3.5f));
            sentenceRate = 0.15f;
            professor.SetActive(false);
        }
        if (count == 16)
        {
            elemental.GetComponent<SpriteRenderer>().sprite = trovoada;

        }
        if (count == 17)
        {
            elemental.SetActive(true);
            elemental.GetComponent<SpriteRenderer>().sprite = eletron;
        }
    
        if (count == 18)
        {
            elemental.SetActive(false);
        }
        if (count == 19)
        {
            elemental.GetComponent<SpriteRenderer>().sprite = torrao;
        }
        if (count == 20)
        {
            elemental.GetComponent<SpriteRenderer>().sprite = rochoso;
            raio.SetActive(false);
            pedra.SetActive(false);
            elemental.SetActive(true);
        }
        if (count == 22)
        {
            raio.SetActive(true);
            pedra.SetActive(true);

        }
        if (count == 27)
        {
            opponent1.SetActive(false);
            opponent2.SetActive(false);
            card.SetActive(false);
            card2.SetActive(false);
            professor.SetActive(true);
        }
        if (count == 28)
        {          
            StartCoroutine(ElementalAttack2Damage(playerUnit.damage * 2));
            isQuestion = false;
            input.SetActive(false);
            sentenceRate = 0.7f;
        }
        if (count == 29)
        {
            StartCoroutine(ElementalAttack3());
            input.SetActive(true);
            inputText.text = "8 - (2X1) ->";
            nextButton.SetActive(false);
            resultado = 6;
            isQuestion = true;
            sentenceRate = 0.2f;
        }
        if (count == 30)
        {
            card2.GetComponent<CardDisplay>().card = tocha;
            card2.GetComponent<CardDisplay>().SetCard();
            enemyUnit = card2.GetComponent<CardDisplay>().card;
            enemyHUD = card2.GetComponent<CardDisplay>();
            enemyStats = card2.GetComponent<EnemyStats>();
            enemyStats.SetStats();
            enemyHUD.SetHP(enemyStats.currentHealth);
        }
        if (count == 31)
        {        
            StartCoroutine(ElementalAttack2Damage(playerUnit.damage));
            isQuestion = false;
            input.SetActive(false);
            sentenceRate = 0.7f;
        }
        if (count == 32)
        {
            StartCoroutine(ElementalAttack2());
            input.SetActive(true);
            inputText.text = "8 - 1  ->";
            nextButton.SetActive(false);
            resultado = 7;
            isQuestion = true;
            sentenceRate = 0.2f;
        }
        if (count == 33)
        {
            card2.GetComponent<CardDisplay>().card = Marinho;
            card2.GetComponent<CardDisplay>().SetCard();
            enemyUnit = card2.GetComponent<CardDisplay>().card;         
            enemyHUD = card2.GetComponent<CardDisplay>();
            enemyStats = card2.GetComponent<EnemyStats>();
            enemyStats.SetStats();
            enemyHUD.SetHP(enemyStats.currentHealth);
        }
        if (count == 34)
        {
            StartCoroutine(ElementalAttack2Damage(playerUnit.damage*3));
            isQuestion = false;
            input.SetActive(false);
            sentenceRate = 0.7f;
        }
        if (count == 37)
        {
            StartCoroutine(ElementalAttack4());
            input.SetActive(true);
            inputText.text = "8 - (3X1) ->";
            nextButton.SetActive(false);
            resultado = 5;
            isQuestion = true;
            sentenceRate = 0.2f;
        }
        if (count == 38)
        {
            opponent1.SetActive(true);
            opponent2.SetActive(true);
            card.GetComponent<RectTransform>().anchoredPosition = opponent1.GetComponent<RectTransform>().anchoredPosition;
            card2.SetActive(true);
            card2.GetComponent<RectTransform>().anchoredPosition = opponent2.GetComponent<RectTransform>().anchoredPosition;
            playerUnit = card.GetComponent<CardDisplay>().card;
            enemyUnit = card2.GetComponent<CardDisplay>().card;
            enemyHUD = card2.GetComponent<CardDisplay>();
            playerHUD = card.GetComponent<CardDisplay>();
            enemyStats = card2.GetComponent<EnemyStats>();
            enemyStats.SetStats();
            enemyHUD.SetHP(enemyStats.currentHealth);
            card.SetActive(true);
        }
        if (count == 39)
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
            sentenceRate = 0.7f;
        }
        if (count == 42)
        {
            ganhadores.SetActive(true);
            perdedores.SetActive(true);
            opponent1.SetActive(false);
            opponent2.SetActive(false);
            card2.SetActive(false);
            card.SetActive(false);
            sentenceRate = 0.2f;
        }
        if (count == 43)
        {
            StartCoroutine(ElementalAttack4());
            StartCoroutine(ElementalAttack2Damage(3*playerUnit.damage));
            sentenceRate = 0.7f;
        }
        if (count == 44)
        {
            opponent1.SetActive(true);
            opponent2.SetActive(true);
            card.GetComponent<RectTransform>().anchoredPosition = opponent1.GetComponent<RectTransform>().anchoredPosition;
            card2.SetActive(true);
            card2.GetComponent<RectTransform>().anchoredPosition = opponent2.GetComponent<RectTransform>().anchoredPosition;        
            enemyUnit = card2.GetComponent<CardDisplay>().card;
            enemyUnit.currentHP = enemyUnit.maxHP;
            enemyHUD = card2.GetComponent<CardDisplay>();
            enemyStats = card2.GetComponent<EnemyStats>();
            enemyStats.SetStats();
            playerUnit = card.GetComponent<CardDisplay>().card;
            playerHUD = card.GetComponent<CardDisplay>();
            sentenceRate = 0.2f;
            professor.SetActive(false);
        }
        if (count == 45)
        {
            lifePointer.SetActive(false);
 
        }
        if (count == 46)
        {
            lifePointer.GetComponent<RectTransform>().Rotate(new Vector3(0,0,-180));
            lifePointer.GetComponent<RectTransform>().anchoredPosition = damagePointer.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 47)
        {
            lifePointer.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            lifePointer.GetComponent<RectTransform>().anchoredPosition = elementPointer.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 48)
        {
            lifePointer.GetComponent<RectTransform>().anchoredPosition = attackPointer.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 49)
            {
                lifePointer.SetActive(true);
            }
            if (count == 50)
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
    public IEnumerator ElementalAttack2Damage(int damage)
    {
        yield return new WaitForSeconds(1f);
        bool isDead = enemyStats.TakeDamage(damage);
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
        Instantiate(fireParticle, attackPoint1.position, Quaternion.identity);
    }
    public IEnumerator ElementalAttack3()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(fireParticle, attackPoint2.position, Quaternion.identity);
        Instantiate(fireParticle, attackPoint1.position, Quaternion.identity);
    }
    public IEnumerator ElementalAttack4()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(fireParticle, attackPoint2.position, Quaternion.identity);
        Instantiate(fireParticle, attackPoint1.position, Quaternion.identity);
        Instantiate(fireParticle, attackPoint3.position, Quaternion.identity);
    }


    public IEnumerator ParticleCoroutine(ParticleSystem particle, Transform particlePosition, float time)
    {
        yield return new WaitForSeconds(time);
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
            if (calculo == resultado)
            {
                manager.GetComponent<DialogueManager>().DialogueText.text = "Muito bem!";
                StartCoroutine(WaitDialogueDrag());
            }
            else
            {
                sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
                manager.GetComponent<DialogueManager>().DialogueText.text = "Acho que este calculo está errado, que tal tentar novamente?";
                StartCoroutine(Wait2DialogueDrag());
            }
        }

    }

    public void BattleEnd()
    {
        nextButton.SetActive(true);
        attackButton.SetActive(false);
        opponent1.SetActive(false);
        enemyCardPos.SetActive(false);
        playerCards[0].SetActive(false);
        playerCards[1].SetActive(false);
        playerCards[2].SetActive(false);
        playerCards[3].SetActive(false);
        playerCards[4].SetActive(false);
        playerCards[5].SetActive(false);
        attackButton.SetActive(false);
        isQuestion = false;
        if (battleSystem.GetComponent<BattleSystemFin>().battleWon == true)
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Wow! Você me derrotou dessa vez!";
        }
        else
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Parece que você perdeu dessa vez, mas foi uma boa batalha!";
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

