using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;

    [SerializeField] TextMeshProUGUI coinsText;

    [SerializeField] AudioSource collectionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grade"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Grade A that you collected: " + coins;
            collectionSound.Play();
        }
    }
}
