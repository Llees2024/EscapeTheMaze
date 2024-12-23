using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public static int coinCount = 0;
    private TextMeshProUGUI coinText;

    void Start()
    {
        coinText = GameObject.Find("Canvas/CoinText").GetComponent<TextMeshProUGUI>();
        UpdateCoinUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinCount++;
            UpdateCoinUI();
            Destroy(gameObject);
        }
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount;
    }
}
