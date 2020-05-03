using UnityEngine;
using System.Collections;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[5];

    private Character character;


    private void Awake()
    {
        character = FindObjectOfType<Character>();

        for (var i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
            Debug.Log(hearts[i]);
        }
    }

    public void Refresh()
    {
        for (var i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(character.Lives > i);
        }
    }
}