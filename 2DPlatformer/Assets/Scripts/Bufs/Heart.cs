using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();

        if (!character || character.Lives == character.maxLives) return;
        character.Lives++;
        Destroy(gameObject);
    }
}
