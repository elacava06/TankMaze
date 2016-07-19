﻿using UnityEngine;
using System.Collections;

public class BlockCreator : MonoBehaviour
{
    public string axisName;
    public float coolDown;
    public GameObject wallSpawner;
    public int width;
    public int height;
    public GameObject wallToGenerate;
    private WallGenerator generator;
    private float fireTime;
    private int controllerNumber;

    private bool isOverWall;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(axisName) > 0 && Time.time > fireTime + coolDown)
        {
            if (checkIfEmpty())
            {
                fireTime = Time.time;
                GameObject square = Instantiate(wallSpawner, transform.position, Quaternion.identity) as GameObject;
                generator = square.GetComponent<WallGenerator>();
                generator.wallToGenerate = wallToGenerate;
                generator.width = width;
                generator.height = height;
            }
        }

    }
    private bool checkIfEmpty()
    {

        return !isOverWall;
    }

    public void setOverWall(bool setting)
    {
        isOverWall = setting;
    }

    public void setControllerNumber(int number)
    {
        controllerNumber = number;
        axisName = axisName + controllerNumber;
    }

}