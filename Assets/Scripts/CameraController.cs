using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        Cursor.visible = false;
        if (!target) 
            target = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        if (!target) return;
        var position = target.position;        
        position.z = -10.0F;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
