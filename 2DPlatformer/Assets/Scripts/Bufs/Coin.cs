using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();

        if (!character) return;
        character.Coins++;
        Destroy(gameObject);
    }
}