using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
    public float turnSpeed;
    public float movementSpeed;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        updateAngle();
        updateMovement();
    }



    // Helper functions:


    // Changes heading angle based on L/R arrow key press/hold
    void updateAngle()
    {
        float angleChange = -1 * Input.GetAxis("tankHorizontal");
        transform.Rotate(Vector3.forward, angleChange * turnSpeed);
    }


    // Changes velocity based on U/D arrow key press/hold
    void updateMovement()
    {
        float movementChange = Input.GetAxis("tankVertical");
        transform.Translate(Vector3.up * movementSpeed * movementChange *Time.deltaTime);
    }
}
