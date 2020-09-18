using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tarefa02 : MonoBehaviour
{
    public GameObject horse;
    public GameObject dragon;
    public GameObject plant;
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
    public int count = 30;
    public GameObject nextButton;
    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;
    public Text firstButtonText;
    public Text secondButtonText;
    public Text thirdButtonText;
    public Transform opponent1;
    public Transform opponent2;
    public Transform elementalPos;
    float nextSentenceTime = 0f;
    public float sentenceRate;
    public int rightAnswer;
    public string sentence;
    public GameObject place1;
    public GameObject place2;
    public GameObject conditions;
   


    public void NextSceneScript()
    {
        if (Time.time >= nextSentenceTime)
        {
            count--;
            nextSentenceTime = Time.time + 1f / sentenceRate;
            if (count == 15)
            {
                place1.SetActive(true);
                place2.SetActive(true);
                conditions.SetActive(true);

            }

            if (count == 16)
            {
                dragon.SetActive(false);
               
            }

            if (count == 17)
            {
                dragon.SetActive(true);
                plant.transform.position = opponent2.transform.position;
                dragon.transform.position = opponent1.transform.position;
                StartCoroutine(AttackCoroutine(dragon, opponent2.transform));
                StartCoroutine(ParticleCoroutine(fireParticle, fireParticlePosition));
                plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(3.5f));
            }
            if (count == 18)
            {
                horse.SetActive(true);
                horse.transform.position = opponent2.transform.position;
                plant.SetActive(true);
                plant.transform.position = opponent1.transform.position;
                StartCoroutine(AttackCoroutine(plant, opponent2.transform));
                StartCoroutine(ParticleCoroutine(plantParticle, plantParticlePosition));
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(3.5f));
            }
            if (count == 19)
            {
                horse.SetActive(true);
                horse.transform.position = opponent1.transform.position;
                dragon.SetActive(true);
                dragon.transform.position = opponent2.transform.position;
                StartCoroutine(AttackCoroutine(horse, opponent2.transform));
                StartCoroutine(ParticleCoroutine(waterParticle, waterParticlePosition));
                dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(3.5f));
            }
            if (count == 23)
            {
                nextButton.SetActive(true);
                firstButton.SetActive(false);
                secondButton.SetActive(false);
                thirdButton.SetActive(false);
                horse.SetActive(false);
            }
            if (count == 24)
            {
                rightAnswer = 1;
                plant.SetActive(false);
                horse.SetActive(true);
                horse.transform.position = elementalPos.transform.position;
                firstButtonText.text = "Marinho do elemento água";
                secondButtonText.text = "Cárnivora do elemento planta";
                thirdButtonText.text = "Tocha do elemento fogo";
            }
            if (count == 25)
            {
                rightAnswer = 2;
                dragon.SetActive(false);
                plant.SetActive(true);
                plant.transform.position = elementalPos.transform.position;
                firstButtonText.text = "Marinho do elemento água";
                secondButtonText.text = "Cárnivora do elemento planta";
                thirdButtonText.text = "Tocha do elemento fogo";
            }
            if (count == 26)
            {
                nextButton.SetActive(false);
                rightAnswer = 3;
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                thirdButton.SetActive(true);
                dragon.SetActive(true);
                dragon.transform.position = elementalPos.transform.position;
                firstButtonText.text = "Marinho do elemento água";
                secondButtonText.text = "Cárnivora do elemento planta";
                thirdButtonText.text = "Tocha do elemento fogo";
            }
            if (count == 29)
            {
                Canvas.Fade();
            }
        }
    }

    
    
    public IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(1.4f);
        dragon.GetComponent<Movement>().state = Movement.State.Idle;
        plant.GetComponent<Movement>().state = Movement.State.Idle;
        horse.GetComponent<Movement>().state = Movement.State.Idle;
    }
    public IEnumerator AttackCoroutine(GameObject elemental, Transform target)
    {
        yield return new WaitForSeconds(2f);
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
        yield return new WaitForSeconds(3.5f);
        Instantiate(particle, particlePosition.position, Quaternion.identity);
    }

    public void buttonOne()
    {
        if (rightAnswer == 1)
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
            StartCoroutine(WaitDialogue());

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
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());

        }
        else
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
            StartCoroutine(WaitDialogue());
        }
    }
    public void buttonThree()
    {
        if (rightAnswer != 3)
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());

        }
        else
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
            StartCoroutine(WaitDialogue());
        }
    }
    public IEnumerator WaitDialogue()
    {
        yield return new WaitForSeconds(1f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
    }
    public IEnumerator Wait2Dialogue()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;

    }
    

}
