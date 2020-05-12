using UnityEngine;
using System.Collections;
using Bufs;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0F;
    
    private Vector3 direction;
    public Vector3 Direction { set => direction = value; }
    public GameObject Parent { set; get; }

    private void Start()
    {
        Destroy(gameObject, 1.0F);
    }

    private void Update()
    {
        var bulletPos = transform.position;
        bulletPos = Vector3.MoveTowards(bulletPos, bulletPos + direction, speed * Time.deltaTime);
        transform.position = bulletPos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != Parent)
            Destroy(gameObject);
    }
}
