﻿using UnityEngine;

public class ShootableMonster : Monster
{
    [SerializeField]
    private float delay = 2.0F;
    
    private Bullet bullet;

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), delay, delay);
    }

    private void Shoot()
    {
        var position = transform.position;          
        position.y += 0.5F;
        var newBullet = Instantiate(bullet, position, bullet.transform.rotation);
        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.GetComponent<Unit>();
        if (!unit || !(unit is Character))
            return;
        if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) 
            ReceiveDamage();
        else 
            unit.ReceiveDamage();
    }
}