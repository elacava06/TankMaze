/* ArduinoConnector by Alan Zucconi
 * http://www.alanzucconi.com/?p=2979
 */
using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class ArduinoConnector : MonoBehaviour {

    /* The serial port where the Arduino is connected. */
    [Tooltip("The serial port where the Arduino is connected")]
    public string port = "COM6";
    /* The baudrate of the serial port. */
    [Tooltip("The baudrate of the serial port")]
    public int baudrate = 9600;

    private SerialPort stream;

    private int timesSent=0;
    private int timesRecieved = 0;

    void Start()
    {
        Open();
        WriteToArduino("PING");
        //read from arduino
        StartCoroutine(
            AsynchronousReadFromArduino(
                (string s) => Debug.Log(s), //this is excecuted after the serial data is read from string s
                10.0f                           //this is the timeout
                )
            );
    }
    void Update()
    {
        
       
    }

    public void Open () {
        // Opens the serial port
        stream = new SerialPort(port, baudrate);
        stream.ReadTimeout = 50;
        stream.Open();
        //this.stream.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

    public void WriteToArduino(string message)
    {
        // Send the request
        timesSent++;
        Debug.Log("Times Sent:" + timesSent);
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }
    

    public IEnumerator AsynchronousReadFromArduino(Action<string> callback, float timeout = float.PositiveInfinity)
    {
        Debug.Log("this is running");
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
                callback(dataString + "   "+ dataString2);
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

    public void Close()
    {
        stream.Close();
    }
}