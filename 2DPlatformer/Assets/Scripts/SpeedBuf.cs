using UnityEngine;
using System.Collections;

public class SpeedBuf : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();

        if (!character) return;
        character.Speed *= 1.5f;
        Destroy(gameObject);
    }
}