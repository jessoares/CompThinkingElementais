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
    public string sentence;



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
            sentence = sentences.Dequeue();
            DialogueText.text = sentence;
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }         
        
    }
   void EndDialogue()
    {
        Debug.Log("End of conver");
    }
   

}
