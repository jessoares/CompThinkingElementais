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
    public GameObject card1;
    public GameObject card2;
    public GameObject winner;
    public GameObject loser;
    public bool isQuestion;
    public GameObject dragGame;
    public Image image1;
    public Image image2;
    public Sprite dragonSprite;
    public Sprite horseSprite;
    public Sprite plantSprite;
    public GameObject placeCard1;
    public GameObject placeCard2;
    public GameObject checkButton;
    public GameObject professor;
    public int placed = 0;



    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 38;
       
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

        if (count == 17)
        {
            isQuestion = false;
            card1.SetActive(false);
            card2.SetActive(false);
            sentenceRate = 0.7f;
            dragGame.SetActive(false);


        }
        if (count == 18)
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            thirdButton.SetActive(false);
            image1.sprite = horseSprite;
            image2.sprite = dragonSprite;
            card1.GetComponent<Winner>().vencedor = true;
            card2.GetComponent<Winner>().vencedor = false;
            card1.GetComponent<RectTransform>().anchoredPosition = placeCard1.GetComponent<RectTransform>().anchoredPosition;
            card2.GetComponent<RectTransform>().anchoredPosition = placeCard2.GetComponent<RectTransform>().anchoredPosition;

        }
        if (count == 19)
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            thirdButton.SetActive(false);
            image1.sprite = horseSprite;
            image2.sprite = plantSprite;
            card1.GetComponent<Winner>().vencedor = false;
            card2.GetComponent<Winner>().vencedor = true;
            card1.GetComponent<RectTransform>().anchoredPosition = placeCard1.GetComponent<RectTransform>().anchoredPosition;
            card2.GetComponent<RectTransform>().anchoredPosition = placeCard2.GetComponent<RectTransform>().anchoredPosition;

        }
        if (count == 20)
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            thirdButton.SetActive(false);
            image1.sprite = dragonSprite;
            image2.sprite = plantSprite;
            card1.GetComponent<Winner>().vencedor = true;
            card2.GetComponent<Winner>().vencedor = false;
            card1.GetComponent<RectTransform>().anchoredPosition = placeCard1.GetComponent<RectTransform>().anchoredPosition;
              card2.GetComponent<RectTransform>().anchoredPosition = placeCard2.GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 21)
            {
            isQuestion = true;
            card1.SetActive(true);
            card2.SetActive(true);
            sentenceRate = 0.7f;
            dragon.SetActive(false);
            dragGame.SetActive(true);
            image1.sprite = dragonSprite;
            image2.sprite = horseSprite;
            checkButton.SetActive(true);
            card1.GetComponent<Winner>().vencedor = false;
            card2.GetComponent<Winner>().vencedor = true;
            plant.SetActive(false);
        }
        if (count == 22)
        {
            loser.SetActive(false);
        }

            if (count == 23)
        {
            winner.SetActive(false);
            loser.SetActive(true);
        }
        if (count == 24)
        {
            winner.SetActive(true);
            plant.SetActive(true);
            plant.transform.position = opponent2.transform.position;
            dragon.transform.position = opponent1.transform.position;
               plant.SetActive(true);
        }
        if (count == 25)
            {
            dragon.transform.rotation = new Quaternion(0, 180, 0, 0);
            plant.transform.rotation = new Quaternion(0, 180, 0, 0);
            plant.transform.position = opponent2.transform.position;
            dragon.SetActive(true);
            dragon.transform.position = opponent1.transform.position;
            dragon.GetComponent<Movement>().attackPoint = opponent2.transform;
            dragon.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(fireParticle, plant.transform, 3f));
            plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(3.5f));
            sentenceRate = 0.7f;
        }
            if (count == 26)
            {
            horse.transform.rotation = new Quaternion(0,0, 0, 0);
            horse.transform.position = opponent2.transform.position;
            plant.SetActive(true);
            plant.transform.position = opponent1.transform.position;
            plant.GetComponent<Movement>().attackPoint = opponent2.transform;
            plant.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(plantParticle, horse.transform, 3f));
            horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(3.5f));
        }
            if (count == 27)
            {
             horse.SetActive(true);
            horse.transform.rotation = new Quaternion(0,180,0,0);
            horse.transform.position = opponent1.transform.position;
            dragon.SetActive(true);
            dragon.transform.position = opponent2.transform.position;
            horse.GetComponent<Movement>().attackPoint = opponent2.transform;
            horse.GetComponent<Movement>().state = Movement.State.Attack;
            StartCoroutine(ParticleCoroutine(waterParticle, dragon.transform, 3f));
            dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(3.5f));
            professor.SetActive(false);
            }
            if(count == 28)
        {
            sentenceRate = 0.15f;
        }
            if (count == 31)
            {
                firstButton.SetActive(false);
                secondButton.SetActive(false);
                thirdButton.SetActive(false);
                horse.SetActive(false);
                isQuestion = false;
        

        }
            if (count == 32)
            {
                rightAnswer = 1;
                plant.SetActive(false);
                horse.SetActive(true);
                horse.transform.position = elementalPos.transform.position;
               
        }
            if (count == 33)
            {
                rightAnswer = 2;
                dragon.SetActive(false);
                plant.SetActive(true);
                plant.transform.position = elementalPos.transform.position;
  
        }
            if (count == 34)
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
            isQuestion = true;
            }
            if (count == 37)
            {
               Canvas.Fade();
            }
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
    yield return new WaitForSeconds(1f);
    elemental.GetComponent<Movement>().attackPoint = target;
    elemental.GetComponent<Movement>().state = Movement.State.Attack;
    StartCoroutine(ParticleCoroutine(particle, position, timer));
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
    thirdButton.SetActive(true);
     manager.GetComponent<DialogueManager>().DialogueText.text = sentence;
   

}
    public IEnumerator Wait2DialogueDrag()
    {
        yield return new WaitForSeconds(3f);

        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;


    }
    public void buttonOne()
{
    if (rightAnswer == 1)
    {
        manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
        firstButton.SetActive(false);
        secondButton.SetActive(false);
        thirdButton.SetActive(false);
        StartCoroutine(WaitDialogue());

    }
    else
    {
        thirdButton.SetActive(false);
        firstButton.SetActive(false);
        secondButton.SetActive(false);
        sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
        manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
        StartCoroutine(Wait2Dialogue());
    }
}
public void buttonTwo()
{
    if (rightAnswer != 2)
    {
        firstButton.SetActive(false);
        secondButton.SetActive(false);
            thirdButton.SetActive(false);
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
        manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
        StartCoroutine(Wait2Dialogue());

    }
    else
    {
        firstButton.SetActive(false);
        secondButton.SetActive(false);
        thirdButton.SetActive(false);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
        StartCoroutine(WaitDialogue());

    }
}
    public void buttonThree()
    {
        if (rightAnswer != 3)
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            thirdButton.SetActive(false);
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());

        }
        else
        {
            firstButton.SetActive(false);
            secondButton.SetActive(false);
            thirdButton.SetActive(false);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Correto!";
            StartCoroutine(WaitDialogue());

        }
    }
    public IEnumerator WaitDialogue()
{
    yield return new WaitForSeconds(3f);
    firstButton.SetActive(true);
    secondButton.SetActive(true);
    thirdButton.SetActive(true);
    manager.GetComponent<DialogueManager>().DisplayNextSentence();
    NextSceneScript();

}
    public IEnumerator WaitDialogueDrag()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();

    }
    public void checkRight()
    {
        if (placed < 1)
        {
            sentence = manager.GetComponent<DialogueManager>().DialogueText.text;
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você precisa escolher um vencedor e um perdedor!";
            StartCoroutine(Wait2DialogueDrag());
        }
        else
        {
            if (card1.GetComponent<Winner>().correto == true && card2.GetComponent<Winner>().correto == true)
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

}
