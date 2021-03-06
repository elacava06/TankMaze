﻿using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour
{
    public float turnSpeed;
    public float movementSpeed;
    public string horizontalAxis;
    public string verticalAxis;
    //private int teamNumber;
    private int controllerNumber;
    // Use this for initialization
    public GameObject gameStateManager;
    private GameState gameManager;

    void Start()
    {
        gameStateManager = GameObject.Find("GameManager");
        gameManager = gameStateManager.GetComponent<GameState>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState == GameState.gameState.play)
        {
            updateAngle();
            updateMovement();
        }
    }
    // Helper functions:


    // Changes heading angle based on L/R arrow key press/hold
    void updateAngle()
    {
        float angleChange = -1 * Input.GetAxis(horizontalAxis);
        transform.Rotate(Vector3.forward, angleChange * turnSpeed*Time.deltaTime);
    }


    // Changes velocity based on U/D arrow key press/hold
    void updateMovement()
    {
        float movementChange = Input.GetAxis(verticalAxis);
        transform.Translate(Vector3.up * movementSpeed * movementChange * Time.deltaTime);
    }

    public void setControllerNumber(int number)
    {
        controllerNumber = number;
        horizontalAxis = "tankHorizontal" + controllerNumber;
        verticalAxis = "tankVertical" + controllerNumber;
    }
}
