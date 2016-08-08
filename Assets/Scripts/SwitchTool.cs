using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchTool : MonoBehaviour
{

    public bool inLobby;
    public string switchAxis;
    public string currentToolName;
    private Queue<string> toolNames = new Queue<string>(new[] {"arm", "drill", "turret", "shield"});

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inLobby)
        {
            if (Input.GetAxis(switchAxis) != 0)
            {
                switchTool();
            }
        }
    }

    void switchTool()
    {
        toolNames.Enqueue(toolNames.Dequeue());
    }
}
