﻿using UnityEngine;

public class LivesBar : MonoBehaviour
{
    private readonly Transform[] hearts = new Transform[5];
    private Character character;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
        for (var i = 0; i < hearts.Length; i++) 
            hearts[i] = transform.GetChild(i);
    }

    public void Refresh()
    {
        for (var i = 0; i < hearts.Length; i++) 
            hearts[i].gameObject.SetActive(i < character.Health);
    }
}
