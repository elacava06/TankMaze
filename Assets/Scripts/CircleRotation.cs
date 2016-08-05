using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;


public class CircleRotation : MonoBehaviour
{

    //normal stuff
    public bool localRotation;
    public bool leftRight;
    public float rotationSpeed;
    public bool drawCircles;
    public float circleRotationSpeed;
    public bool customController=false;
    public float customControllerSpeed=10f;
    public float reverseThreshold;
    public string singleAxisName;
    public string verticalAxisName;
    public string horizontalAxisName;
    private Vector2 input1;
    private Vector2 input2;
    private float customInput1;
    private float customInput2;
    public enum direction { clockwise, counterClockwise, neither };
    public direction currentDirection = direction.neither;  //why can't i make this public?
    public float inputSpeed;
    SpriteRenderer myImage;
    private float zrotation = 0;
    private int controllerNumber;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        myImage = GetComponentInChildren<SpriteRenderer>();
        if (customController)
        {
            OpenSerialPort();
            
        }
        if (GameControl.control != null)
        {
            if (GameControl.control.getUseGameControl())
            {
                this.setLocalRotation(GameControl.control.getLocalRotation());
                this.setRotationSpeed(GameControl.control.getRotationSpeed());
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (leftRight)
        {
            incrementRotationLocal();
        }
        if (drawCircles)
        {
            doCircleRotation();
        }
        if (customController)
        {
            pingThenListen();
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
            transform.rotation = Quaternion.Euler(0, 0, zrotation + initialRotation.eulerAngles.z);
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
    void customRotation(float input)
    {
        //Debug.Log(input);
        //Debug.Log(currentDirection);
        customInput1 = customInput2;
        customInput2 = input;
        float change = customInput2 - customInput1;
//Debug.Log(change);
        if (Mathf.Abs(change) < reverseThreshold) //if the change is too large (passing the zero point) then don't change the direction
        {
            if (change < 0)
            {
                currentDirection = direction.clockwise;
            }
            else
            {
                currentDirection = direction.counterClockwise;
            }

            if (currentDirection == direction.clockwise)
            {
                rotateObject(change * customControllerSpeed * Time.deltaTime);
            }
            else if (currentDirection == direction.counterClockwise)
            {
                rotateObject(change * customControllerSpeed * Time.deltaTime);
            }
        }

        
    }
    bool blah = true;
    void customButton()
    {
        if (!blah)
        {
            StartCoroutine(turnBlack());
        }
    }

    IEnumerator turnBlack()
    {
        blah = true;
        myImage.color = Color.black;
        yield return new WaitForSeconds(1.0f);
        myImage.color = Color.white;
        blah = false;
    }






    //new stuff for serial port for custom controller
    public string serialPort = "COM6";
    public int baudrate;
    SerialPort stream;

    public void OpenSerialPort()
    {
        // Opens the serial port
        stream = new SerialPort(serialPort, baudrate);
        stream.ReadTimeout = 50;
        stream.Open();
        //this.stream.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

    public void WriteToArduino(string message)
    {
        // Send the request
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }

    void pingThenListen()
    {
        //send the first ping
        WriteToArduino("PING");
        //read from arduino
        StartCoroutine(
            AsynchronousReadFromArduino(
                (float a) => customRotation(a), //this is excecuted after the serial data is read from string s
                () => customButton(),
                10.0f                           //this is the timeout
                )
            );
    }

    public IEnumerator AsynchronousReadFromArduino(Action<float> callback, Action callback2, float timeout = float.PositiveInfinity)
    {
        //Debug.Log("this is running");
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        string dataString = null;
        string dataString2 = null;

        while (diff.Milliseconds < timeout)
        {
            // A single read attempt
            try
            {
                dataString = stream.ReadLine();
                dataString2 = stream.ReadLine();
            }
            catch (TimeoutException)
            {
                dataString = null;
                dataString2 = null;
            }

            if (dataString != null && dataString2 != null)
            {
                callback(float.Parse(dataString));
                if(dataString2 == "1")
                {
                    callback2();
                }
                yield return null;
            }
            else {
                yield return new WaitForSeconds(0.05f);
            }

            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        }

        yield return null;
    }

    public void CloseSerialPort()
    {
        stream.Close();
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
