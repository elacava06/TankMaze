﻿using UnityEngine;
using System.Collections;

public class ArmFamilySpawner : MonoBehaviour {

    public bool allowedToChangeDuringGameplay;
    public int playerNumberInTank;
    public GameObject turret;
    public float turretOffset;
    public GameObject arm;
    public float armOffset;
    public GameObject drill;
    public GameObject shield;
    private int[] controllerNumbers;
    public int tankNumber;
    public characterClass myClass;
    private GameObject[] arms = new GameObject[4];
    private string myAxis;
    private int armNumActive;
    public float coolDown;
    private float fireTime = 0.0F;
    public GameObject gameStateManager;
    private GameState gameManager;

    void Start()
    {
        
        if (GameControl.control != null)
        {
            if (GameControl.control.getUseGameControl())
            {
                setAllowedToChange(GameControl.control.getAllowedToChange());
            }
        }

        gameStateManager = GameObject.Find("GameManager");
        gameManager = gameStateManager.GetComponent<GameState>();
        controllerNumbers = GetComponentInParent<TankInfo>().getControllerNumbers();
        myAxis = "changeArm" + controllerNumbers[playerNumberInTank];
        //GetComponent<CircleRotation>().singleAxisName = "shield" + controllerNumbers[playerNumberInTank];

        arms[0] = Instantiate(arm, transform.position + transform.rotation * (new Vector3(0, armOffset)), transform.rotation) as GameObject;
        arms[0].transform.SetParent(transform);
        arms[0].GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[playerNumberInTank]);
        arms[0].GetComponentInChildren<BlockCreator>().setControllerNumber(controllerNumbers[playerNumberInTank]);
        arms[0].SetActive(false);
        arms[1] = Instantiate(drill, transform.position, transform.rotation) as GameObject;
        arms[1].transform.SetParent(transform);
        arms[1].GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[playerNumberInTank]);
        arms[1].GetComponent<DestroyBlocks>().setControllerNumber(controllerNumbers[playerNumberInTank]);
        arms[1].SetActive(false);
        arms[2] = Instantiate(turret, transform.position + transform.rotation * (new Vector3(0, turretOffset)), transform.rotation) as GameObject;
        arms[2].transform.SetParent(transform);
        arms[2].GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[playerNumberInTank]);
        arms[2].GetComponent<Turret>().setControllerNumber(controllerNumbers[playerNumberInTank]);
        arms[2].SetActive(false);
        arms[3] = Instantiate(shield, transform.position, transform.rotation) as GameObject;
        arms[3].transform.SetParent(transform);
        arms[3].GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[playerNumberInTank]);
        arms[3].SetActive(false);
        if (myClass == characterClass.miner)
        {
            armNumActive = playerNumberInTank - 1;
            arms[armNumActive].SetActive(true);
        }
        if (myClass == characterClass.shooter)
        {
            armNumActive = playerNumberInTank + 1;
            arms[armNumActive].SetActive(true);
        }

    }

    public void setClass(characterClass input)
    {
        myClass = input;
    }

    void Update()
    {
        if (gameManager.currentGameState == GameState.gameState.lobby)
        {
            if (Input.GetButtonDown(myAxis) && Input.GetAxisRaw(myAxis) > 0)
            {
                switchArms(1);
            }
            if (Input.GetButtonDown(myAxis) && Input.GetAxisRaw(myAxis) < 0)
            {
                switchArms(-1);
            }
        }
        else if (this.getAllowedToChange())
        {
            //do the checking for switch here
            if (Time.time > fireTime)
            {
                if (Input.GetButtonDown(myAxis) && Input.GetAxisRaw(myAxis) > 0)
                {
                    switchArms(1);
                }
                if (Input.GetButtonDown(myAxis) && Input.GetAxisRaw(myAxis) < 0)
                {
                    switchArms(-1);
                }
            }
        }
        
    }

    public void setAllowedToChange(bool value)
    {
        allowedToChangeDuringGameplay = value;
    }

    public bool getAllowedToChange()
    {
        return allowedToChangeDuringGameplay;
    }

    void switchArms(int i)
    {
        fireTime = Time.time + coolDown;
        var currentRotation = arms[armNumActive].transform.localRotation;
        arms[armNumActive].SetActive(false);
        armNumActive += i;
        
        if (armNumActive < 0)
        {
            armNumActive = arms.Length - 1;
        }
        else if(armNumActive > arms.Length - 1)
        {
            armNumActive = 0;
        }
        
        arms[armNumActive].SetActive(true);
        arms[armNumActive].transform.localRotation = currentRotation;
    }
    
}
