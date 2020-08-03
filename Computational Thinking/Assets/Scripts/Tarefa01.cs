using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarefa01 : MonoBehaviour
{
    public GameObject horse;
    public GameObject dragon;
    public GameObject plant;
    public GameObject elementais;
    public GameObject pointer;
    public CanvasEffects Canvas;
    public DialogueManager manager;
    int count = 11;
    public void NextSceneScript()
    {
        count--;
        if (count == 6)
        {
            dragon.GetComponent<Movement>().state = Movement.State.Move;
            plant.GetComponent<Movement>().state = Movement.State.Move;
            horse.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(MoveCoroutine());
        }
        if (count == 7)
        {
            dragon.GetComponent<Movement>().state = Movement.State.Move;
            plant.GetComponent<Movement>().state = Movement.State.Move;
            horse.GetComponent<Movement>().state = Movement.State.Move;
            StartCoroutine(MoveCoroutine());
        }
        if (count == 8)
        {
            pointer.SetActive(true);
        }
        if (count == 9)
        {
            Canvas.Flash();
            StartCoroutine(SummonCoroutine());
        }
        if (count == 10)
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


}
