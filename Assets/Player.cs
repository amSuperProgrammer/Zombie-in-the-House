using UnityEngine;

public class Player : MonoBehaviour
{
    int vertical = 1;
    int horizontal = 1;
    bool lockMove = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && vertical != 12 && lockMove)
        {
            vertical += 1;
            lockMove= false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && vertical != 1 && lockMove)
        {
            vertical -= 1;
            lockMove= false;
        } 
        else if (Input.GetKeyDown(KeyCode.A) && horizontal != 1 && lockMove)
        {
            horizontal -= 1;
            lockMove= false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && horizontal != 12 && lockMove)
        {
            horizontal += 1;
            lockMove= false;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(horizontal, transform.position.y, vertical), Time.deltaTime * 5f);

        if (transform.position == new Vector3(horizontal, transform.position.y, vertical))
            lockMove = true;
    }

}
