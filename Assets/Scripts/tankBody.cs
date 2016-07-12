using UnityEngine;
using System.Collections;

public class tankBody : MonoBehaviour
{
    //public variables
    public float turnSpeed;
    public float movementSpeed;

    //private variables
    private Rigidbody2D body;
    
    
    // Called once at start:
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Called once per frame:
    void Update()
    {
        updateAngle();
        updateMovement();
    }



// Helper functions:


    // Changes heading angle based on L/R arrow key press/hold
    void updateAngle()
    {
        float angleChange = -1 * Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, angleChange * turnSpeed);
    }


    // Changes velocity based on U/D arrow key press/hold
    void updateMovement()
    {
        float movementChange = Input.GetAxis("Vertical");
        body.velocity = new Vector3(0, 0, 0);
        Vector3 heading = transform.rotation * Vector3.up;
        body.velocity = heading * movementSpeed * movementChange;
    }
}
