using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator anim;

    [SerializeField]
    private Queue <string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        anim.SetBool("IsOpen", true);
        UpdateName(dialogue.name);

        sentences.Clear();

        foreach (string sentance in dialogue.sentences) 
        {
            sentences.Enqueue(sentance);
        }

        DisplayNextSentence();
    }

    public void UpdateName(string name)
    {
        nameText.text = name;
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentance = sentences.Dequeue();
        dialogueText.text = sentance;
    }

    void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
    }
}
