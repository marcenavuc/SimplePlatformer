using System;
using UnityEngine;
using System.Collections;

public class Buf : MonoBehaviour
{
    
    private Character character;
    public void Awake()
    {
        character = FindObjectOfType<Character>();
        var parametrs = gameObject.AddComponent<Character>();
    }

    public void DoSomethingWithCharacter(Character character)
    {
    }

    public bool CheckCharacter(Character character)
    {
        return true;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();
        if (CheckCharacter(character)) return;
        DoSomethingWithCharacter(character);
        Destroy(gameObject);
    }
}