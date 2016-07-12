using UnityEngine;
using System.Collections;

public class tankBody : MonoBehaviour
{
    //public variables
    public float turnSpeed;
    public float movementSpeed;

    //private variables
    private Rigidbody2D body;
    private GameObject collectibleHolding;


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


    // On collision with the collectible, picks it up if not holding one
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collectible")
        {
            if (collectibleHolding == null)
            {
                // Sets the collectible on the hood of the tank
                collectibleHolding = collision.gameObject;
                collectibleHolding.transform.SetParent(transform);
                collectibleHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;
                collectibleHolding.transform.localPosition = new Vector3(0, 1.43f, 0);
            }
            
        }
    }
}
