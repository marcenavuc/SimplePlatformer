using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.gameObject.GetComponentInChildren<Unit>();
        if (unit)
            unit.Die();
    }
}
