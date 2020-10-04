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
    public Sprite fire;
    public Sprite water;
    public Sprite grass;
    public Sprite dragonSprite;
    public Sprite horseSprite;
    public Sprite plantSprite;
    public int count;
    public GameObject nextButton;
    public GameObject firstButton;
    public GameObject secondButton;
    public Text firstButtonText;
    public Text secondButtonText;
    public Transform opponent1;
    public Transform opponent2;
    public float nextSentenceTime;
    public float sentenceRate;
    public int rightAnswer;
    public string sentence;
    public GameObject place1;
    public GameObject place2;
    public GameObject conditions;
    public bool isQuestion;

    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 30;
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
       
        if (Time.time >= nextSentenceTime)
        {
            nextSentenceTime = Time.time + 1f / sentenceRate;
            nextButton.SetActive(false);
            count--;
            if (count == 2)
            {
                dragon.SetActive(false);
                plant.SetActive(false);
                horse.SetActive(false);
                firstButton.SetActive(false);
                secondButton.SetActive(false);
            }
            if (count == 1)
            {
              
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(plant, opponent2.transform));
            }
            if (count == 2)
            {
                firstButtonText.text = "Cárnivora";
                secondButtonText.text = "Marinho";
                dragon.SetActive(false);
                plant.SetActive(true);
                plant.transform.position = opponent1.transform.position;
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(plant, opponent2.transform));
            }
            if (count == 3)
            {
              
                dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(horse, opponent1.transform));

            }
            if (count == 4)
            {
                firstButtonText.text = "Tocha";
                secondButtonText.text = "Marinho";
                horse.SetActive(true);
                horse.transform.position = opponent2.transform.position;
                plant.SetActive(false);
                dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(horse, opponent1.transform));

            }
            if (count == 5)
            {
                plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(dragon, opponent2.transform));

            }
            if (count == 5)
            {
                firstButtonText.text = "Tocha";
                horse.SetActive(false);
                dragon.SetActive(true);
                dragon.transform.position = opponent1.transform.position;
                secondButtonText.text = "Cárnivora";
               

            }
            if (count == 6)
            {
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(plant, opponent2.transform));

            }
            if (count == 7)
            {
                isQuestion = true;
                nextButton.SetActive(false);
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                dragon.SetActive(false);
                horse.transform.position = opponent1.transform.position;
                plant.transform.position = opponent2.transform.position;
                firstButtonText.text = "Marinho";
                secondButtonText.text = "Cárnivora";
                

            }
            if (count == 8)
            {
                plant.SetActive(true);
                dragon.transform.position = dragonPoint.transform.position;
                horse.transform.position = horsePoint.transform.position;
                plant.transform.position = plantPoint.transform.position;
                dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
                horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
                plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;
                dragon.GetComponent<SpriteRenderer>().sprite = dragonSprite;
                horse.GetComponent<SpriteRenderer>().sprite = horseSprite;
                plant.GetComponent<SpriteRenderer>().sprite = plantSprite;
            }
            if (count == 9)
            {
                isQuestion = false;
                firstButton.SetActive(false);
                secondButton.SetActive(false);
                nextButton.SetActive(true);
                dragon.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ElementalAttack(dragon));
                plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());
            }
            if (count == 13)
            {
                rightAnswer = 2;
                isQuestion = true;
                nextButton.SetActive(false);
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                firstButtonText.text = "Fogo";
                secondButtonText.text = "Planta";

            }
            if (count == 11)
            {
                horse.SetActive(true);
                dragon.transform.position = dragonPoint.transform.position;
                horse.transform.position = horsePoint.transform.position;
                plant.transform.position = plantPoint.transform.position;
                dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
                horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
                plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;
            }
            if (count == 12)
            {
                isQuestion = false;
                firstButton.SetActive(false);
                secondButton.SetActive(false);
                plant.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ElementalAttack(plant));
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());
                nextButton.SetActive(true);
            }
                    
            if (count == 13)
            {
                rightAnswer = 2;
                isQuestion = true;
                nextButton.SetActive(false);
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                firstButtonText.text = "Fogo";
                secondButtonText.text = "Água";     
               
            }
            if (count == 15)
            {
                dragon.SetActive(true);
                dragon.transform.position = dragonPoint.transform.position;
                horse.transform.position = horsePoint.transform.position;
                plant.transform.position = plantPoint.transform.position;
                dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
                horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
                plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;
            }
            if (count == 16)
            {
                isQuestion = false;
                nextButton.SetActive(true);
                firstButton.SetActive(false);
                secondButton.SetActive(false);
                horse.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ElementalAttack(horse));
                dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());
            }
            if (count == 17)
            {
                isQuestion = true;
                nextButton.SetActive(false);
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                rightAnswer = 1;
                firstButtonText.text = "Utilizar água";
                secondButtonText.text = "Utilizar gravetos ou folhas secas";

            }
            if (count == 18)
            {
                dragon.GetComponent<SpriteRenderer>().sprite = fire;
                horse.GetComponent<SpriteRenderer>().sprite = water;
                plant.GetComponent<SpriteRenderer>().sprite = grass;
             
            }
            if (count == 19)
            {
                dragon.SetActive(true);
                dragon.transform.position = dragonPoint.transform.position;
                horse.transform.position = horsePoint.transform.position;
                plant.transform.position = plantPoint.transform.position;
                dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
                horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
                plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;

            }
            if (count == 20)
            {
                horse.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ParticleCoroutine(waterParticle, waterParticlePosition));
                StartCoroutine(ElementalAttack(horse));
                dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());

            }
            if (count == 21)
            {
                plant.SetActive(true);
                dragon.transform.position = dragonPoint.transform.position;
                horse.transform.position = horsePoint.transform.position;
                plant.transform.position = plantPoint.transform.position;
                dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
                horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
                plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;

            }
            if (count == 22)
            {
                dragon.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ParticleCoroutine(fireParticle, fireParticlePosition));
                StartCoroutine(ElementalAttack(dragon));
                plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());
            }
            if (count == 24)
            {
                pointer.SetActive(false);
            }
            if (count == 25)
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
            if (count == 26)
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
            if (count == 27)
            {
                pointer.SetActive(true);
            }
            if (count == 28)
            {
                Canvas.Flash();
                StartCoroutine(SummonCoroutine());
               
            }
            if (count == 29)
            {
                Canvas.Fade();

               
            }
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
    public IEnumerator AttackCoroutine(GameObject elemental,Transform target)
    {
        yield return new WaitForSeconds(2.7f);
        elemental.GetComponent<Movement>().attackPoint = target;
        elemental.GetComponent<Movement>().state = Movement.State.Attack;
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

    public IEnumerator ParticleCoroutine(ParticleSystem particle, Transform particlePosition)
    {
        yield return new WaitForSeconds(1.4f);
        Instantiate(particle, particlePosition.position, Quaternion.identity);
    }
  
    public IEnumerator Wait2Dialogue()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;

    }
    public void buttonOne()
    {
        if (rightAnswer == 1)
        {
            manager.GetComponent<DialogueManager>().DisplayNextSentence();
            NextSceneScript();
            nextSentenceTime = 0f;
        }
        else
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());
        }
    }
    public void buttonTwo()
    {
        if (rightAnswer != 2)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());

        }
        else
        {
            manager.GetComponent<DialogueManager>().DisplayNextSentence();
            NextSceneScript();
            nextSentenceTime = 0f;
        }
    }
    public void buttonThree()
    {
        if (rightAnswer != 3)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());

        }
        else
        {
            manager.GetComponent<DialogueManager>().DisplayNextSentence();
            NextSceneScript();
            nextSentenceTime = 0f;
        }
    }

}
