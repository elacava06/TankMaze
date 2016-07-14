using UnityEngine;
using System.Collections;

public class circleRotation : MonoBehaviour {

    public bool leftRight;
    public float rotationSpeed;
    public bool drawCircles;
    public float circleRotationSpeed;
    public string verticalAxisName;
    public string horizontalAxisName;
    private Vector2 input1;
    private Vector2 input2;
    public enum direction { clockwise, counterClockwise, neither };
    public direction currentDirection = direction.neither;  //why can't i make this public?
    public float inputSpeed;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (leftRight)
        {
            incrementRotation();
        }
        else if (drawCircles)
        {
            doCircleRotation();
        }
	}
    void incrementRotation()
    {
        float change = Input.GetAxis(horizontalAxisName);
        transform.Rotate(Vector3.forward, -change * rotationSpeed);
    }
    void doCircleRotation()
    {
        getRotationDirection(); //sets currentDirection
        inputSpeed = (input2 - input1).magnitude;
        if (currentDirection == direction.clockwise)
        {
            transform.Rotate(Vector3.forward, -inputSpeed * circleRotationSpeed * Time.deltaTime);
        }
        else if(currentDirection == direction.counterClockwise)
        {
            transform.Rotate(Vector3.forward, inputSpeed * circleRotationSpeed * Time.deltaTime);
        }

    }
    void getRotationDirection()
    {
        //record 2 input values to compare
        input1 = input2;    //this is the previous input
        input2 = new Vector2(Input.GetAxis(horizontalAxisName), Input.GetAxis(verticalAxisName));   //this is the new input

        //check to see if the input is counterclockwise or clockwise
        if(input2.x == input1.x && input2.y == input1.y)        //the stick hasn't moved
        {
            currentDirection = direction.neither;
        }


        //the stick moved


        else if(input2.y > 0 && input1.y > 0)    //stick in top half
        {
            if(input2.x < input1.x)             //moved left
            {
                currentDirection = direction.counterClockwise;
            }
            else
            {
                currentDirection = direction.clockwise;
            }
        }
        else if (input2.y < 0 && input1.y < 0)  //stick in bottom half
        {
            if (input2.x > input1.x)            //moved right
            {
                currentDirection = direction.counterClockwise;
            }
            else
            {
                currentDirection = direction.clockwise;
            }
        }
        else if (input2.x > 0 && input1.x > 0)  //stick in right half
        {
            if (input2.y > input1.y)            //moved up
            {
                currentDirection = direction.counterClockwise;
            }
            else
            {
                currentDirection = direction.clockwise;
            }

        }
        else if (input2.x < 0 && input1.x < 0)  //stick in left half
        {
            if (input2.y < input1.y)            //moved down
            {
                currentDirection = direction.counterClockwise;
            }
            else
            {
                currentDirection = direction.clockwise;
            }
        }
    }
}
