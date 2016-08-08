using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JoystickMonitor : MonoBehaviour {

    private int numJoysticks;
    private string[] joystickList;
    private Text myText;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        numJoysticks = 0;
        joystickList = Input.GetJoystickNames();
        //Debug.Log(joystickList);
        string compileText=" ";
        foreach(string joystickName in joystickList)
        {
            if(joystickName != "")
            {
                numJoysticks++;
                compileText += "\n" + joystickName;
            }
            
        }
        string temp = "Joysticks Connected: " + numJoysticks;
        Debug.Log(temp);
        myText.text = temp+ "\n"+compileText;

	}
}
