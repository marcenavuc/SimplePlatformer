using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int amountOfBullets = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();

        if (!character || character.Bullets == character.maxBullets) return;
        character.Bullets += amountOfBullets;
        Destroy(gameObject);
    }
}