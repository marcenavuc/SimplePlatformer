using UnityEngine;

namespace Bufs
{
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
}