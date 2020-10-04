using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;
    public Queue<string> sentences;
    private float timer;
    public bool primeiroCorreto;
    public Tarefa01 tarefa01;
    public string sentence;
    public float nextSentenceTime = 0f;
    public float sentenceRate;

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
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
        }
    }
   void EndDialogue()
    {
        Debug.Log("End of conver");
    }
   

}
