using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsBar : MonoBehaviour
{
    private Text amountOfCoins;

    private Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
        amountOfCoins = GetComponentInChildren<Text>();
    }

    public void Refresh()
    {
        amountOfCoins.text = character.Coins.ToString();
    }
}