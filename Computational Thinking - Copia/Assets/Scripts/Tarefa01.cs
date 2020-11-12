using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tarefa01 : MonoBehaviour
{
    public GameObject horse;
    public GameObject dragon;
    public GameObject plant;
    public GameObject elementais;
    public GameObject pointer;
    public GameObject professor;
    public CanvasEffects Canvas;
    public DialogueManager manager;
    public ParticleSystem fireParticle;
    public Transform fireParticlePosition;
    public ParticleSystem waterParticle;
    public Transform waterParticlePosition;
    public ParticleSystem plantParticle;
    public Transform plantParticlePosition;
    public GameObject dragonPoint;
    public GameObject horsePoint;
    public GameObject plantPoint;
    public int count;
    public GameObject nextButton;
    public GameObject attackButton;
    public GameObject firstButton;
    public GameObject secondButton;
    public Text firstButtonText;
    public Text secondButtonText;
    public Transform opponent1;
    public Transform opponent2;
    public Transform dragonPointer;
    public Transform horsePointer;
    public Transform plantPointer;
    public float nextSentenceTime;
    public float sentenceRate;
    public int rightAnswer;
    public string sentence;
    public GameObject place1;
    public GameObject place2;
    public GameObject conditions;
    public GameObject dragGame;
    public bool isQuestion;
    public Tarefa01Battle battleSystem;
    public GameObject[] playerCards;

    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 43;
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

        if (count == 2)
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Escolha um elemental para batalhar nesta rodada!";
            playerCards[0].SetActive(true);

            playerCards[1].SetActive(true);

            playerCards[2].SetActive(true);

            playerCards[3].SetActive(true);

            playerCards[4].SetActive(true);

            playerCards[5].SetActive(true);

            attackButton.SetActive(true);
            dragGame.SetActive(true);
            isQuestion = true;
        }
        
        if (count == 6)
        {
            dragon.SetActive(false);
            plant.SetActive(false);
            horse.SetActive(false);
            firstButton.SetActive(false);
            secondButton.SetActive(false);
        }
        if (count == 7)
        {
            isQuestion = false;
            horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(3.5f));
            plant.GetComponent<Movement>().attackPoint = opponent2.transform;
            plant.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(plantParticle, horse.transform, 3f));
            sentenceRate = 0.7f;

        }
        if (count == 8)
        {
            isQuestion = true;
            rightAnswer = 1;
            firstButtonText.text = "Cárnivora";
            secondButtonText.text = "Marinho";
            dragon.SetActive(false);
            plant.SetActive(true);
            plant.transform.position = opponent1.transform.position;
            horse.transform.position = opponent2.transform.position;
            plant.transform.rotation = new Quaternion(0, 0, 0, 0);
            firstButton.SetActive(true);
            secondButton.SetActive(true);
            sentenceRate = 0.15f;
        }

        if (count == 9)
        {
            isQuestion = false;
            dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(3.5f));
            horse.GetComponent<Movement>().attackPoint = opponent1.transform;
            horse.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(waterParticle, dragon.transform, 3f));
            sentenceRate = 0.7f;
        }
        if (count == 10)
        {
            isQuestion = true;
            rightAnswer = 2;
            firstButtonText.text = "Tocha";
            secondButtonText.text = "Marinho";
            horse.SetActive(true);
            dragon.transform.position = opponent1.transform.position;
            horse.transform.position = opponent2.transform.position;
            plant.SetActive(false);
            horse.transform.rotation = new Quaternion(0,0, 0, 0);
            firstButton.SetActive(true);
            secondButton.SetActive(true);
            sentenceRate = 0.15f;
        }
        if (count == 11)
        {
            isQuestion = false;
            plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(3.5f));
            dragon.GetComponent<Movement>().attackPoint = opponent2.transform;
            dragon.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(fireParticle, plant.transform, 3f));
            sentenceRate = 0.7f;
        }
        if (count == 12)
        {
            isQuestion = true;
            rightAnswer = 1;
            firstButtonText.text = "Tocha";
            horse.SetActive(false);
            dragon.SetActive(true);
            dragon.transform.position = opponent1.transform.position;
            plant.transform.position = opponent2.transform.position;
            secondButtonText.text = "Cárnivora";
            firstButton.SetActive(true);
            secondButton.SetActive(true);
            sentenceRate = 0.15f;
        }
        if (count == 13)
        {
            isQuestion = false;
            horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(3.5f));
            plant.GetComponent<Movement>().attackPoint = opponent1.transform;
            plant.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(plantParticle,horse.transform,3f));
            sentenceRate = 0.7f;
        }
        if (count == 14)
        {
            rightAnswer = 2;
            isQuestion = true;
            nextButton.SetActive(false);
            firstButton.SetActive(true);
            secondButton.SetActive(true);
            dragon.SetActive(false);
            horse.transform.position = opponent1.transform.position;
            plant.transform.position = opponent2.transform.position;
            firstButtonText.text = "Marinho";
            secondButtonText.text = "Cárnivora";
            plant.transform.rotation = new Quaternion(0, 180, 0, 0);
            sentenceRate = 0.15f;


        }
        if (count == 17)
        {
            dragon.SetActive(true);
            dragon.transform.position = dragonPoint.transform.position;
            horse.transform.position = horsePoint.transform.position;
            plant.transform.position = plantPoint.transform.position;
            dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
            horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
            plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;
            professor.SetActive(false);


        }
        if (count == 18)
        {
            isQuestion = false;
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            horse.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(ElementalAttack(horse));
            StartCoroutine(ParticleCoroutine(waterParticle, dragon.transform, 1.4f));
            plant.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
            dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
            horsePoint.GetComponent<Movement>().state = Movement.State.Move;
            plantPoint.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(PointMoveCoroutine());
            sentenceRate = 0.7f;

        }
        if (count == 19)
        {
            rightAnswer = 1;
            isQuestion = true;
            nextButton.SetActive(false);
            firstButton.SetActive(true);
            secondButton.SetActive(true);
            firstButtonText.text = "Água";
            secondButtonText.text = "Plantas";
            sentenceRate = 0.2f;

        }
        if (count == 20)
        {
            plant.SetActive(true);
            dragon.transform.position = dragonPoint.transform.position;
            horse.transform.position = horsePoint.transform.position;
            plant.transform.position = plantPoint.transform.position;
            dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
            horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
            plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;

        }
        if (count == 21)
        {
            isQuestion = false;
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            dragon.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(ElementalAttack(dragon));
            StartCoroutine(ParticleCoroutine(fireParticle, plant.transform, 1.4f));
            horse.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(2.7f));
            dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
            horsePoint.GetComponent<Movement>().state = Movement.State.Move;
            plantPoint.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(PointMoveCoroutine());
            sentenceRate = 0.7f;

        }

        if (count == 22)
        {
            rightAnswer = 2;
            isQuestion = true;
            nextButton.SetActive(false);
            firstButton.SetActive(true);
            secondButton.SetActive(true);
            firstButtonText.text = "Água";
            secondButtonText.text = "Fogo";
            sentenceRate = 0.2f;

        }
        if (count == 23)
        {
            horse.SetActive(true);
            dragon.transform.position = dragonPoint.transform.position;
            horse.transform.position = horsePoint.transform.position;
            plant.transform.position = plantPoint.transform.position;
            dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
            horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
            plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;
        }
        if (count == 24)
        {
            isQuestion = false;
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            plant.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(ElementalAttack(plant));
            StartCoroutine(ParticleCoroutine(plantParticle, horse.transform, 1.4f));
            horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
            dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
            horsePoint.GetComponent<Movement>().state = Movement.State.Move;
            plantPoint.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(PointMoveCoroutine());
            sentenceRate = 0.7f;
        }
        if (count == 25)
        {
            isQuestion = true;
            nextButton.SetActive(false);
            firstButton.SetActive(true);
            secondButton.SetActive(true);
            rightAnswer = 1;
            firstButtonText.text = "Água";
            secondButtonText.text = "Fogo";
            sentenceRate = 0.2f;
        }
        if (count == 27)
        {
            sentenceRate = 0.7f;
            pointer.SetActive(false);
        }
        if (count == 28)
        {
            StartCoroutine(ParticleCoroutine(plantParticle, plantParticlePosition, 1.4f));
            pointer.transform.parent = plant.transform;
            pointer.transform.position = plantPointer.position;

        }
        if (count == 29)
        {
            StartCoroutine(ParticleCoroutine(waterParticle, waterParticlePosition, 1.4f));
            pointer.transform.parent = horse.transform;
            pointer.transform.position = horsePointer.position;
        }
        if (count == 30)
        {
            StartCoroutine(ParticleCoroutine(fireParticle, fireParticlePosition, 1.4f));
            pointer.SetActive(true);
            pointer.transform.parent = dragon.transform;
            pointer.transform.position = dragonPointer.position;

        }
        if (count == 31)
        {
            sentenceRate = 0.3f;
        }
        if (count == 32)
        {
            dragon.SetActive(true);
            dragon.transform.position = dragonPoint.transform.position;
            horse.transform.position = horsePoint.transform.position;
            plant.transform.position = plantPoint.transform.position;
            dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
            horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
            plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;


        }
        if (count == 33)
        {
            horse.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(ParticleCoroutine(waterParticle, waterParticlePosition, 1.4f));
            StartCoroutine(ElementalAttack(horse));
            dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
            dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
            horsePoint.GetComponent<Movement>().state = Movement.State.Move;
            plantPoint.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(PointMoveCoroutine());
            sentenceRate = 0.7f;

        }
        if (count == 34)
        {
            plant.SetActive(true);
            dragon.transform.position = dragonPoint.transform.position;
            horse.transform.position = horsePoint.transform.position;
            plant.transform.position = plantPoint.transform.position;
            dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
            horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
            plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;
            sentenceRate = 0.2f;

        }
        if (count == 35)
        {
            dragon.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(ParticleCoroutine(fireParticle, fireParticlePosition, 1.4f));
            StartCoroutine(ElementalAttack(dragon));
            plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(2.7f));
            dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
            horsePoint.GetComponent<Movement>().state = Movement.State.Move;
            plantPoint.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(PointMoveCoroutine());
            sentenceRate = 0.7f;
        }
        if (count == 36)
        {
            sentenceRate = 0.2f;
        }
        if (count == 37)
        {
          
            pointer.SetActive(false);
        }
        if (count == 38)
        {
            dragon.GetComponent<Movement>().state = Movement.State.Move;
            plant.GetComponent<Movement>().state = Movement.State.Move;
            horse.GetComponent<Movement>().state = Movement.State.Move;
            dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
            horsePoint.GetComponent<Movement>().state = Movement.State.Move;
            plantPoint.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(MoveCoroutine());
            StartCoroutine(PointMoveCoroutine());
        }
        if (count == 39)
        {
            dragon.GetComponent<Movement>().state = Movement.State.Move;
            plant.GetComponent<Movement>().state = Movement.State.Move;
            horse.GetComponent<Movement>().state = Movement.State.Move;
            dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
            horsePoint.GetComponent<Movement>().state = Movement.State.Move;
            plantPoint.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(MoveCoroutine());
            StartCoroutine(PointMoveCoroutine());
        }
        if (count == 40)
        {
            pointer.SetActive(true);

        }
        if (count == 41)
        {
            Canvas.Flash();
            StartCoroutine(SummonCoroutine());
        }
           
        if (count == 42)
        {
            Canvas.Fade();
        }
    }
    public IEnumerator SummonCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        elementais.SetActive(true);
    }
    public IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(1.4f);
        dragon.GetComponent<Movement>().state = Movement.State.Idle;
        plant.GetComponent<Movement>().state = Movement.State.Idle;
        horse.GetComponent<Movement>().state = Movement.State.Idle;
    }
    public IEnumerator AttackCoroutine(GameObject elemental, Transform target, ParticleSystem particle, Transform position, float timer)
    {
        yield return new WaitForSeconds(2.7f);
        elemental.GetComponent<Movement>().attackPoint = target;
        elemental.GetComponent<Movement>().state = Movement.State.Attack;
        StartCoroutine(ParticleCoroutine(particle, position, timer));
    }
    public IEnumerator PointMoveCoroutine()
    {
        yield return new WaitForSeconds(1.4f);
        dragonPoint.GetComponent<Movement>().state = Movement.State.Idle;
        horsePoint.GetComponent<Movement>().state = Movement.State.Idle;
        plantPoint.GetComponent<Movement>().state = Movement.State.Idle;
    }
    public IEnumerator ElementalAttack(GameObject elemental)
    {
        yield return new WaitForSeconds(1f);
        elemental.GetComponent<Movement>().state = Movement.State.Idle;
    }
    public IEnumerator ParticleCoroutine(ParticleSystem particle, Transform particlePosition, float time)
    {
        yield return new WaitForSeconds(time);
        ParticleSystem go = Instantiate(particle, particlePosition.position, Quaternion.identity);
        Destroy(go.gameObject, 1.5f);
    }

    public IEnumerator Wait2Dialogue()
    {
        yield return new WaitForSeconds(3f);
        firstButton.SetActive(true);
        secondButton.SetActive(true);
        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;
    }
    public void ButtonOne()
    {
        if (rightAnswer == 1)
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            StartCoroutine(WaitDialogue());

        }
        else
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());
        }
    }
    public void ButtonTwo()
    {
        if (rightAnswer != 2)
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());
        }
        else
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
            StartCoroutine(WaitDialogue());
        }
    }
    public IEnumerator WaitDialogue()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
    }
    public void BattleEnd()
    {
            nextButton.SetActive(true);
            attackButton.SetActive(false);
            playerCards[0].SetActive(false);
            playerCards[1].SetActive(false);
            playerCards[2].SetActive(false);
            playerCards[3].SetActive(false);
            playerCards[4].SetActive(false);
            playerCards[5].SetActive(false);
            attackButton.SetActive(false);
        isQuestion = false;
            dragGame.SetActive(false);
            if (battleSystem.GetComponent<Tarefa01Battle>().battleWon == true)
            {
                manager.GetComponent<DialogueManager>().DialogueText.text = "Wow! Você me derrotou dessa vez!";
            }
            else
            {
                manager.GetComponent<DialogueManager>().DialogueText.text = "Parece que você perdeu dessa vez, mas não desista!";
            }

        }
    }


