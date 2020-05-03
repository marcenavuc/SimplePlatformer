using System;
using UnityEngine;

public class Monster : Unit
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>()) 
            ReceiveDamage();

        var character = other.GetComponent<Character>();
        if (character) 
            character.ReceiveDamage();
    }
}
