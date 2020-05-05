using UnityEngine;
using System.Collections;
using System.Linq;
 
public class MovingMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F;
 
    private Vector3 direction;
    private SpriteRenderer sprite;
 
    public void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
 
    protected  void Start()
    {
        direction = transform.right;
    }
 
    protected  void Update()
    {
        sprite.flipX = direction.x > 0;
        Move();
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        var unit = other.GetComponent<Unit>();
        var bullet = other.GetComponent<Bullet>();
        if (unit is Character)
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F)
                ReceiveDamage();
            else
                unit.ReceiveDamage();
        if (bullet)
            ReceiveDamage();
    }
 
    private void Move()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + 0.5F * direction.x * transform.right, 0.1F);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>()))
            direction *= -1.0F;
       
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}