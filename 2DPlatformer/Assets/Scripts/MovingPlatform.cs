using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2.5f;
    private bool shouldReturn;
    public string axis = "X";
    public float shift = 3f;

    private void Update()
    {
        var position = transform.position;
        if (axis == "X")
        {
            if (position.x > shift)
                shouldReturn = true;
            else if (position.x < -shift)
                shouldReturn = false;
        }
        else
        {
            if (position.y > shift)
                shouldReturn = true;
            else if (position.y < -shift)
                shouldReturn = false;
        }
        
        switch (axis)
        {
            case "X" when shouldReturn:
                position.x -= speed * Time.deltaTime;
                break;
            case "X":
                position.x += speed * Time.deltaTime;
                break;
            case "Y" when shouldReturn:
                position.y -= speed * Time.deltaTime;
                break;
            case "Y":
                position.y += speed * Time.deltaTime;
                break;
        }

        transform.position = position;
    }
}

