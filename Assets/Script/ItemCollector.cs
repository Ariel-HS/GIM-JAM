using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private TextMeshProUGUI coinsText;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
        }
    }

    public int GetCoin()
    {
        return coins;
    }

    public void ResetCoin()
    {
        coins = 0;
    }
}
