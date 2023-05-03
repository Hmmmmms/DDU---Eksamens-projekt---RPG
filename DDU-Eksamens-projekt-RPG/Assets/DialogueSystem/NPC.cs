using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCDropLoot NPCdropLoot;

    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, NPCdropLoot);
        FindObjectOfType<PlayerController>().DialogueOn();
    }
    
}
