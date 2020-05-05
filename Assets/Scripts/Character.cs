﻿using UnityEngine;
using System.Collections;

public class Character : Unit
{
    public override int Health
    {
        get => health;
        set
        {
            if (value < 5)
                health = value;
            healthBar.Refresh();
        }
    }

    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;
    
    private bool canShoot = true;
    private bool isGrounded;
    private Bullet bullet;
    private LivesBar healthBar;
    private int health = 5;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private CharState State
    {
        get => (CharState) animator.GetInteger("State");
        set => animator.SetInteger("State", (int) value);
    }

    private void Awake()
    {
        healthBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) 
            State = CharState.Idle;
        if (Input.GetButtonDown("Fire1") && canShoot) 
            TryToShoot();
        if (Input.GetButton("Horizontal")) 
            Run();
        if (isGrounded && Input.GetButtonDown("Jump")) 
            Jump();
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");
        var position = transform.position;
        position = Vector3.MoveTowards(position, position + direction, speed * Time.deltaTime);
        transform.position = position;
        sprite.flipX = direction.x < 0.0F;
        
        if (isGrounded) 
            State = CharState.Run;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void TryToShoot()
    {
        var position = transform.position; 
        position.y += 0.8F;
        var newBullet = Instantiate(bullet, position, bullet.transform.rotation);
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        StartCoroutine(StartShooting());
    }
    
    private IEnumerator StartShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
    }

    public override void ReceiveDamage()
    {
        Health--;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        var size = Physics2D.OverlapCircleNonAlloc(transform.position, 0.3F, new Collider2D[100]);
        isGrounded = size > 1;
        if (!isGrounded) 
            State = CharState.Jump;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var newBullet = other.gameObject.GetComponent<Bullet>();
        if (newBullet && newBullet.Parent != gameObject) 
            ReceiveDamage();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponentInParent<MovingPlatform>()) 
            transform.parent = other.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponentInParent<MovingPlatform>() || !isGrounded) 
            transform.parent = null;
    }
}

public enum CharState
{
    Idle,
    Run,
    Jump
}