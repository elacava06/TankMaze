﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Represents a tank
 */
public class TankInfo : MonoBehaviour
{

    public int teamNumber;
    private Vector3 spawnPoint;
    private int[] controllerNumbers;

    // Use this for initialization
    void Start()
    {

        if (teamNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            //transform.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            //transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (teamNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            //transform.Find("turret(Clone)").Find("turretImage").gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = Color.blue;
        }
        spawnPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (Transform child in GetComponentInChildren<Transform>())
        //{
        //    Debug.Log(child.name);
        //}
    }

    /*
     * Gets the point where the tank was spawned
     * @return Vector3 that is the position of the spawn point
     */
    public Vector3 getSpawnPoint()
    {
        return this.spawnPoint;
    }

    public int[] getControllerNumbers()
    {
        return this.controllerNumbers;
    }

    public void setControllerNumbers(int[] numbers)
    {
        controllerNumbers = numbers;
    }

}
