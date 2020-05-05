using UnityEngine;
 
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    public float shift;
    [SerializeField]
    private string axis = "X";
   
    private Vector3 nextPos;
    private Vector3 initPos;
    private Vector3 biasVector;
 
    public void Awake()
    {
        initPos = transform.position;
        biasVector = axis == "X"
            ? new Vector3(shift, 0)
            : new Vector3(0, shift);
        nextPos = initPos + biasVector;
    }
 
    private void Update()
    {
        var currentPos = transform.position;
        if (currentPos == initPos - biasVector)
            nextPos = initPos + biasVector;
        if (currentPos == initPos + biasVector)
            nextPos = initPos - biasVector;
        transform.position = Vector3.MoveTowards(currentPos, nextPos, speed * Time.deltaTime);
    }
}