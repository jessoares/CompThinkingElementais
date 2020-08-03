using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public CanvasEffects fade;
    public DialogueManager manager;

    public void Start()
    {
        manager.sentences = new Queue<string>();
        manager.StartDialogue(dialogue);
    }
        

}
