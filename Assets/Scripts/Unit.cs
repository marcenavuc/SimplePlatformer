using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public virtual int Health { get; set; }
    public float MovementSpeed { get; set; }
    
    public virtual void ReceiveDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
