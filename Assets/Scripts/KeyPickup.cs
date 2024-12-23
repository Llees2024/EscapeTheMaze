using UnityEngine;
using TMPro; // For TextMeshPro

public class KeyPickup : MonoBehaviour
{
    public static int keyCount = 0;
    private TextMeshProUGUI keysText;

    void Start()
    {
        // Try to find the text object in the scene
        GameObject textObject = GameObject.Find("Canvas/KeysText");
        if (textObject == null)
        {
            Debug.LogError("KeysText object not found! Check your Canvas and hierarchy.");
            return; 
        }

        keysText = textObject.GetComponent<TextMeshProUGUI>();
        if (keysText == null)
        {
            Debug.LogError("KeysText does not have a TextMeshProUGUI component! Check the object.");
            return; 
        }

        Debug.Log("KeysText successfully assigned.");
        UpdateKeyUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            if (keysText == null)
            {
                Debug.LogError("keysText is null in OnTriggerEnter! Check if it was assigned properly.");
                return; 
            }

            keyCount++;
            UpdateKeyUI();
            Destroy(gameObject);
        }
    }

    private void UpdateKeyUI()
    {
        if (keysText != null)
        {
            keysText.text = "Keys: " + keyCount;
        }
        else
        {
            Debug.LogError("keysText is null in UpdateKeyUI! This should not happen.");
        }
    }
}
