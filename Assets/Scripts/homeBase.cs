﻿using UnityEngine;
using System.Collections;

public class homeBase : MonoBehaviour
{

    public bool inUse = false;
    public int teamNumber;

    // Use this for initialization
    void Start()
    {
        if (teamNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (teamNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
