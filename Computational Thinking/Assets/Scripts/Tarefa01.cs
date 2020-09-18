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
    public GameObject dragonGrass;
    public GameObject horseGrass;
    public GameObject plantGrass;
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
    public Text firstButtonText;
    public Text secondButtonText;
    public Transform opponent1;
    public Transform opponent2;
    float nextSentenceTime = 0f;
    public float sentenceRate;

    public void NextSceneScript()
    {
        if (Time.time >= nextSentenceTime)
        {
            count--;
            nextSentenceTime = Time.time + 1f / sentenceRate;
            if (count == 3)
            {
                dragon.SetActive(false);
                plant.SetActive(false);
                horse.SetActive(false);
                firstButton.SetActive(false);
                secondButton.SetActive(false);
            }
            if (count == 4)
            {
                firstButtonText.text = "Cárnivora";
                secondButtonText.text = "Marinho";
                dragon.SetActive(false);
                plant.SetActive(true);
                plant.transform.position = opponent1.transform.position;
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(plant, opponent2.transform));
            }
            if (count == 5)
            {
                firstButtonText.text = "Tocha";
                secondButtonText.text = "Marinho";
                horse.SetActive(true);
                horse.transform.position = opponent2.transform.position;
                plant.SetActive(false);
                dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(horse, opponent1.transform));

            }
            if (count == 6)
            {
                firstButtonText.text = "Tocha";
                horse.SetActive(false);
                dragon.SetActive(true);
                dragon.transform.position = opponent1.transform.position;
                secondButtonText.text = "Cárnivora";
                plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(dragon, opponent2.transform));

            }
            if (count == 7)
            {

                nextButton.SetActive(false);
                firstButton.SetActive(true);
                secondButton.SetActive(true);
                dragon.SetActive(false);
                horse.transform.position = opponent1.transform.position;
                plant.transform.position = opponent2.transform.position;
                firstButtonText.text = "Marinho";
                secondButtonText.text = "Cárnivora";
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
                StartCoroutine(AttackCoroutine(horse, opponent2.transform));

            }
            if (count == 9)
            {
                plant.SetActive(true);
                dragon.transform.position = dragonPoint.transform.position;
                horse.transform.position = horsePoint.transform.position;
                plant.transform.position = plantPoint.transform.position;
                dragon.GetComponent<Movement>().timeCounter = dragonPoint.GetComponent<Movement>().timeCounter;
                horse.GetComponent<Movement>().timeCounter = horsePoint.GetComponent<Movement>().timeCounter;
                plant.GetComponent<Movement>().timeCounter = plantPoint.GetComponent<Movement>().timeCounter;
                dragonGrass.SetActive(true);
                horseGrass.SetActive(true);
                plantGrass.SetActive(true);
                dragon.GetComponent<SpriteRenderer>().sprite = dragonSprite;
                horse.GetComponent<SpriteRenderer>().sprite = horseSprite;
                plant.GetComponent<SpriteRenderer>().sprite = plantSprite;
            }
            if (count == 10)
            {
                dragon.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ElementalAttack(dragon));
                plant.GetComponent<Damage>().StartCoroutine(plant.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());
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
                plant.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ElementalAttack(plant));
                horse.GetComponent<Damage>().StartCoroutine(horse.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());
            }
            if (count == 14)
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
                horse.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(ElementalAttack(horse));
                dragon.GetComponent<Damage>().StartCoroutine(dragon.GetComponent<Damage>().DeathCoroutine(2.7f));
                dragonPoint.GetComponent<Movement>().state = Movement.State.Move;
                horsePoint.GetComponent<Movement>().state = Movement.State.Move;
                plantPoint.GetComponent<Movement>().state = Movement.State.Move;
                StartCoroutine(PointMoveCoroutine());
            }
            if (count == 18)
            {
                dragon.GetComponent<SpriteRenderer>().sprite = fire;
                horse.GetComponent<SpriteRenderer>().sprite = water;
                plant.GetComponent<SpriteRenderer>().sprite = grass;
                dragonGrass.SetActive(false);
                horseGrass.SetActive(false);
                plantGrass.SetActive(false);
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
   
}
