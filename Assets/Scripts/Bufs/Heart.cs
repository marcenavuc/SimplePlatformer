using UnityEngine;

namespace Bufs
{
    public class Heart : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var character = other.GetComponent<Character>();
            if (!character || character.Health == character.maxLives) return;
            character.Health++;
            Destroy(gameObject);
        }
    }
}
