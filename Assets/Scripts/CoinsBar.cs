using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsBar : MonoBehaviour
{
    // private Transform[] hearts = new Transform[5];
    private Text amountOfCoins;

    private Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
        amountOfCoins = FindObjectOfType<Text>();
    }

    public void Refresh()
    {
        amountOfCoins.text = character.Coins.ToString();
    }
}