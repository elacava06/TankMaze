using UnityEngine;
using System.Collections;

public class Corgi : MonoBehaviour
{

    private int xVelocity = 0;
    private int yVelocity = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateMovement();
    }

    private void updateMovement()
    {
        //increases y velocity (up to 10) while up key is pressed
        if (Input.GetKey("up"))
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 10)
            {
                yVelocity += 1;
            }
        }

        //decreases y velocity (down to -10) while down key is pressed
        if (Input.GetKey("down"))
        {
            if (GetComponent<Rigidbody2D>().velocity.y > -10)
            {
                yVelocity += -1;
            }
        }

        //decreases x velocity (down to -10) while left key is pressed
        if (Input.GetKey("left"))
        {
            if (GetComponent<Rigidbody2D>().velocity.x > -10)
            {
                xVelocity += -1;
            }
        }

        //increases x velocity (up to 10) while right key is pressed
        if (Input.GetKey("right"))
        {
            if (GetComponent<Rigidbody2D>().velocity.x < 10)
            {
                xVelocity += 1;
            }
        }

        //sets new velocity
        GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
    }
}
