using UnityEngine;
using System.Collections;

public class Character : Unit
{
    [SerializeField] public int maxLives = 5;
    [SerializeField] public int maxBullets = 5;
    [SerializeField] private int lives = 5;
    [SerializeField] private int bullets = 5;

    public int Lives 
    {
        get => lives;
        set
        {
            if (value <= maxLives) lives = value;
            livesBar.Refresh();
        }
    }

    private LivesBar livesBar;

    public int Bullets 
    {
        get => bullets;
        set
        {
            if (value <= maxBullets) bullets = value;
            bulletBar.Refresh();
        }
    }

    private BulletBar bulletBar;

    // [SerializeField]
    // private float speed = 3.0f;
    //
    // public float Speed
    // {
    //     get => speed;
    //     set => speed = value;
    // }
    [field: SerializeField] 
    public float Speed { get; set; }

    [SerializeField] private int coins;
    public int Coins
    {
        get => coins;
        set
        {
            coins = value;
            coinsBar.Refresh();
        }
    }

    private CoinsBar coinsBar;
    
    [SerializeField]
    private float jumpForce = 15.0F;

    private bool isGrounded = false;

    private Bullet bullet;

    private CharState State
    {
        get => (CharState) animator.GetInteger("State");
        set => animator.SetInteger("State", (int) value);
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        coinsBar = FindObjectOfType<CoinsBar>();
        bulletBar = FindObjectOfType<BulletBar>();
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("Bullet");
        Speed = 3.5f;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");

        var position = transform.position;
        var target = position + direction;
        position = Vector3.MoveTowards(position, target, Speed * Time.deltaTime);
        transform.position = position;

        sprite.flipX = direction.x < 0.0F;

        if (isGrounded) State = CharState.Run;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    private void Shoot()
    {
        if (Bullets <= 0) return;
        Bullets--;
        var position = transform.position;
        position.y += 0.8F;
        var newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    public override void ReceiveDamage()
    {
        Lives--;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        var bullet = collider.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject)
        {
            ReceiveDamage();
        }
    }
}


public enum CharState
{
    Idle,
    Run,
    Jump
}