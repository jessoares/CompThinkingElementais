using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;
    public Queue<string> sentences;
    private float timer;
    public bool primeiroCorreto;
    public Tarefa01 tarefa01;
    public string sentence;
    float nextSentenceTime;
    public float sentenceRate;



    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (Time.time >= nextSentenceTime)
        {
            sentence = sentences.Dequeue();
            DialogueText.text = sentence;
            nextSentenceTime = Time.time + 1f / sentenceRate;
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            if (sentences.Count == 7)
            {
                primeiroCorreto = false;
            }
            if (sentences.Count == 6)
            {
                primeiroCorreto = true;

            }
            if (sentences.Count == 5)
            {
                primeiroCorreto = false;
            }
            if (sentences.Count == 4)
            {
                primeiroCorreto = true;

            }
        }
    }
    void EndDialogue()
    {
        Debug.Log("End of conver");
    }
    public void LeftButton()
    {
        if (primeiroCorreto == true)
        {
            DialogueText.text = "Correto!";
            StartCoroutine(WaitDialogue());

        }
        else
        {
            DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());
        }
    }
    public void RightButton()
    {
        if (primeiroCorreto == true)
        {
            DialogueText.text = "Hm, acho que você errou por pouco, vamos tentar de novo?";
            StartCoroutine(Wait2Dialogue());

        }
        else
        {
            DialogueText.text = "Correto!";
            StartCoroutine(WaitDialogue());
        }
    }
    public IEnumerator WaitDialogue()
    {
        yield return new WaitForSeconds(1f);
        DisplayNextSentence();
        tarefa01.NextSceneScript();
    }
    public IEnumerator Wait2Dialogue()
    {
        yield return new WaitForSeconds(3f);
        DialogueText.text = sentence;

    }


}
