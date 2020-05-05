using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var character = other.GetComponent<Character>();
        if (!character)
            return;

        character.Health++;
        Destroy(gameObject);
    }
}
