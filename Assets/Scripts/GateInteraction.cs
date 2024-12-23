using UnityEngine;
using TMPro;

public class GateInteraction : MonoBehaviour
{
    public int requiredCoins = 5;
    public int requiredKeys = 1;
    private TextMeshProUGUI interactionText;
    private bool playerInRange = false;

    public float raycastDistance = 5f;

    void Start()
    {
        interactionText = GameObject.Find("Canvas/InteractionText").GetComponent<TextMeshProUGUI>();
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Gate"))
            {
                playerInRange = true;
                interactionText.text = "Press E to open the gate (Requires " + requiredCoins + " coins and " + requiredKeys + " keys)";
                interactionText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (CoinPickup.coinCount >= requiredCoins && KeyPickup.keyCount >= requiredKeys)
                    {
                        OpenGate();
                    }
                    else
                    {
                        Debug.Log("Not enough coins or keys to open the gate.");
                    }
                }
            }
            else
            {
                playerInRange = false;
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            playerInRange = false;
            interactionText.gameObject.SetActive(false);
        }
    }

    private void OpenGate()
    {
        Debug.Log("Gate opened!");
        gameObject.SetActive(false);
        interactionText.gameObject.SetActive(false);


        interactionText.text = "<i>I wonder if I have anything I can use to stop this guy... (left click to shoot)</i>";
        interactionText.gameObject.SetActive(true);


        Invoke("HideDialogue", 5f);
    }

    private void HideDialogue()
    {
        interactionText.gameObject.SetActive(false);
    }
}
