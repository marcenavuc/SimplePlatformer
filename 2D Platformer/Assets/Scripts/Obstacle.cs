using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.GetComponent<Unit>();
        if (unit && unit is Character) 
            unit.ReceiveDamage();
    }
}
