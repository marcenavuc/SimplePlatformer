using UnityEngine;
using System.Collections;

public class BulletBar : MonoBehaviour
{
    private Transform[] bullets = new Transform[5];

    private Character character;


    private void Awake()
    {
        character = FindObjectOfType<Character>();

        for (var i = 0; i < bullets.Length; i++)
            bullets[i] = transform.GetChild(i);
        Refresh();
    }

    public void Refresh()
    {
        for (var i = 0; i < bullets.Length; i++)
            bullets[i].gameObject.SetActive(character.Bullets > i);
    }
}