using UnityEngine;
using TMPro;

public class PetAI : MonoBehaviour
{
    public TextMeshProUGUI interactionText;
    public string[] dialogue;
    private bool playerInRange = false;
    private int dialogueIndex = 0;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueIndex < dialogue.Length)
            {
                interactionText.text = dialogue[dialogueIndex];
                dialogueIndex++;
            }
            else
            {
                interactionText.text = "Press E to continue...";
                dialogueIndex = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactionText.gameObject.SetActive(true);
            interactionText.text = "Press E to interact with your pet";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionText.gameObject.SetActive(false);
        }
    }
}
