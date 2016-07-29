using UnityEngine;
using System.Collections;

public class CircleRotation : MonoBehaviour
{

    public bool localRotation;
    public bool leftRight;
    public float rotationSpeed;
    public bool drawCircles;
    public float circleRotationSpeed;
    public string singleAxisName;
    public string verticalAxisName;
    public string horizontalAxisName;
    private Vector2 input1;
    private Vector2 input2;
    public enum direction { clockwise, counterClockwise, neither };
    public direction currentDirection = direction.neither;  //why can't i make this public?
    public float inputSpeed;

    private float zrotation = 0;
    private int controllerNumber;

    void Start()
    {
        if (GameControl.control.getUseGameControl())
        {
            this.setLocalRotation(GameControl.control.getLocalRotation());
            this.setRotationSpeed(GameControl.control.getRotationSpeed());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!localRotation)
        {
            transform.localRotation = Quaternion.identity;
        }
        if (leftRight)
        {
            incrementRotationLocal();
        }
        if (drawCircles)
        {
            doCircleRotation();
        }
    }

    void rotateObject(float byHowMuch)
    {
        if (localRotation)
        {
            transform.Rotate(Vector3.forward, byHowMuch);
        }

        else {
            zrotation += byHowMuch;
            transform.rotation = Quaternion.Euler(0, 0, zrotation);
        }
    }
    void incrementRotationLocal()
    {
        float change = Input.GetAxis(singleAxisName);
        rotateObject(-change * rotationSpeed);
    }
    void doCircleRotation()
    {
        getRotationDirection(); //sets currentDirection
        inputSpeed = (input2 - input1).magnitude;
        if (currentDirection == direction.clockwise)
        {
            rotateObject(-inputSpeed * circleRotationSpeed * Time.deltaTime);
        }
        else if (currentDirection == direction.counterClockwise)
        {
            rotateObject(inputSpeed * circleRotationSpeed * Time.deltaTime);
        }

    }
    void getRotationDirection()
    {
        //record 2 input values to compare
        input1 = input2;    //this is the previous input
        input2 = new Vector2(Input.GetAxis(horizontalAxisName), Input.GetAxis(verticalAxisName));   //this is the new input

        //check to see if the input is counterclockwise or clockwise
        if (input2.x == input1.x && input2.y == input1.y)        //the stick hasn't moved
        {
            currentDirection = direction.neither;
        }


        //the stick moved


        else if (input2.y > 0 && input1.y > 0)    //stick in top half
        {
            if (input2.x < input1.x)             //moved left
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

    public void setControllerNumber(int number)
    {
        controllerNumber = number;
        singleAxisName = singleAxisName + controllerNumber;
    }

    /*
     * Sets the rotation speed
     * @param amount the int that will become the new rotation speed
     */
    public void setRotationSpeed(float amount) 
    {
        rotationSpeed = amount;
    }

    /*
     * Gets the rotation speed
     * @return float the rotation speed
     */
    public float getRotationSpeed()
    {
        return rotationSpeed;
    }

    /*
     * Sets the local rotation
     * @param value the bool value that will become the local rotation
     */
    public void setLocalRotation(bool value)
    {
        localRotation = value;
    }

    /*
     * Gets the local rotation
     * @return bool true if local rotation is on, false if local rotation is off
     */
    public bool getLocalRotation()
    {
        return localRotation;
    }
}
