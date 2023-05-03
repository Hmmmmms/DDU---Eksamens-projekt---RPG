using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI ContinueText;

    public Animator animator;

    private Queue<string> sentences;

    private NPCDropLoot NPCdroploot;

    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue (Dialogue dialogue, NPCDropLoot NPCdropLoot)
    {
        NPCdroploot = NPCdropLoot;

        animator.SetBool("IsOpen", true);

        ContinueText.text = ("Press Enter To Continue ");

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        if (sentences.Count == 1)
        {
            ContinueText.text = ("Press Enter To Exit ");
        }
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        NPCdroploot.NPCdropLoot();
        animator.SetBool("IsOpen", false);
        FindObjectOfType<PlayerController>().DialogueOff();
    }
}
