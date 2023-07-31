using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        //Would be better for singleton pattern

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
