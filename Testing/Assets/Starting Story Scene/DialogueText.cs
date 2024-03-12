using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public Dialogue princessDialogue;
    public Dialogue demonKingDialogue;
    public Dialogue guardiansDialogue;

    public Image backgroundImage;
    public Image BlackBackground;

    public Button continueButton;

    private bool canProgressDialogue = false;

    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProgressDialogue();
        }
        StartCoroutine(StartDialogues());

        continueButton.onClick.AddListener(ProgressDialogue);
    }

    IEnumerator StartDialogues()
    {
        yield return new WaitForSeconds(3f);

        // Princess Dialogue
        princessDialogue.name = "Princess";
        princessDialogue.sentences = new string[]
        {
            "Oh, what a lovely day in our kingdom!"
        };
        FindObjectOfType<DialogueManager>().StartDialogue(princessDialogue);
        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);
        canProgressDialogue = false;

        princessDialogue.name = "Princess";
        princessDialogue.sentences = new string[]
        {
            "The sun is shining, and the birds are singing."
        };
        FindObjectOfType<DialogueManager>().StartDialogue(princessDialogue);
        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);
        canProgressDialogue = false;

        princessDialogue.name = "Princess";
        princessDialogue.sentences = new string[]
        {
            "I feel so blessed to be part of this beautiful world."
        };
        FindObjectOfType<DialogueManager>().StartDialogue(princessDialogue);
        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);
        canProgressDialogue = false;

        // Demon King Dialogue
        demonKingDialogue.name = "Demon King";
        demonKingDialogue.sentences = new string[]
        {
            "Hahaha! The princess is enjoying her day, little does she know..."
        };
        FindObjectOfType<DialogueManager>().StartDialogue(demonKingDialogue);
        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);
        canProgressDialogue = false;

        demonKingDialogue.name = "Demon King";
        demonKingDialogue.sentences = new string[]
        {
            "I, the Demon King, have come to claim what is rightfully mine!"
        };
        FindObjectOfType<DialogueManager>().StartDialogue(demonKingDialogue);
        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);
        canProgressDialogue = false;

        demonKingDialogue.name = "Demon King";
        demonKingDialogue.sentences = new string[]
        {
            "Soon, this kingdom will know the wrath of darkness."
        };
        FindObjectOfType<DialogueManager>().StartDialogue(demonKingDialogue);

        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);
        canProgressDialogue = false;

        princessDialogue.name = "Princess";
        princessDialogue.sentences = new string[]
        {
            "Oh No, Someone Please Help Me!!!"
        };
        FindObjectOfType<DialogueManager>().StartDialogue(princessDialogue);
        
        DestroyBackgroundImage();

        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);
        canProgressDialogue = false;

        // Guardians Dialogue
        guardiansDialogue.name = "Guardian";
        guardiansDialogue.sentences = new string[]
        {
            "Did you hear that? Something is not right."
        };
        FindObjectOfType<DialogueManager>().StartDialogue(guardiansDialogue);

        DestroyBlackImage();

        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);

        guardiansDialogue.name = "Guardian";
        guardiansDialogue.sentences = new string[]
        {
            "Indeed, fellow Guardian. We must investigate."
        };
        FindObjectOfType<DialogueManager>().StartDialogue(guardiansDialogue);
        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);

        guardiansDialogue.name = "Guardian";
        guardiansDialogue.sentences = new string[]
        {
            "I sense the presence of the Demon King. We cannot let him harm the princess!"
        };
        FindObjectOfType<DialogueManager>().StartDialogue(guardiansDialogue);
        yield return new WaitUntil(() => continueButton.interactable);

        yield return new WaitUntil(() => canProgressDialogue);

        // Load the next scene
        LoadNextScene();
    }

    void DestroyBackgroundImage()
    {
        if (backgroundImage != null)
        {
            Destroy(backgroundImage.gameObject);
        }
    }

    void DestroyBlackImage()
    {
       if(BlackBackground != null)
        {
            Destroy(BlackBackground.gameObject);
        }
    }

    void ProgressDialogue()
    {
        canProgressDialogue=true;
    }

    void LoadNextScene()
    {
        // Assuming you have a SceneLoader script to handle scene transitions
        SceneLoader.LoadNextScene();
    }
}
