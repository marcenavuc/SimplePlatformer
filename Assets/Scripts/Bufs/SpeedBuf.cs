using System;
using UnityEngine;
using System.Collections;
using System.Timers;

public class SpeedBuf : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float time = 5.0f;
    [SerializeField] private float jump = 1f;
    private bool isOver = false;
    private Character character;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        character = collider.GetComponent<Character>();

        if (!character) return;
        Debug.Log(character.Speed);
        character.Speed *= speed;
        character.JumpForce *= jump;
        StartCoroutine(SetTimer());
    }

    private void FixedUpdate()
    {
        if (!isOver) return;
        Debug.Log(character.Speed);
        character.Speed /= speed;
        character.JumpForce /= jump;
        Destroy(gameObject);
    }

    private IEnumerator SetTimer()
    {
        isOver = false;
        yield return new WaitForSeconds(time);
        isOver = true;
    }
}