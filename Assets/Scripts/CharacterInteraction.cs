using UnityEngine;
using TMPro;

public class CharacterInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionText;
    private bool isNearCharacter = false;
    private int currentDialogueIndex = 0;
    private string[] dialogueLines;
    private string continuePrompt = "Press E to continue.";

    public string[] customDialogueLines;

    void Start()
    {
        dialogueLines = new string[]
        {
            "You must enter the maze!",
            "Collect coins and keys to open each door.",
            "Press E to continue."
        };

        interactionText.text = "";
    }

    void Update()
    {
        if (isNearCharacter && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextDialogue();
        }
    }

    private void ShowNextDialogue()
    {
        if (customDialogueLines.Length > 0)
        {
            if (currentDialogueIndex < customDialogueLines.Length)
            {
                interactionText.text = customDialogueLines[currentDialogueIndex] + "\n" + continuePrompt;
                currentDialogueIndex++;
            }
            else
            {
                interactionText.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCharacter = true;
            interactionText.text = "Press E to interact with the character.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCharacter = false;
            interactionText.text = "";
        }
    }
}
