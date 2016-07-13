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
    private bool isHoldingCollectible = false;


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


    void OnTriggerEnter2D(Collider2D trigger)
    {
        // Upon touching collectible, picks it up if not holding one
        if (trigger.gameObject.tag == "collectible")
        {
            if (isHoldingCollectible == false)
            {
                // Puts collectible on the hood
                isHoldingCollectible = true;
                collectibleHolding = trigger.gameObject;
                collectibleHolding.transform.SetParent(transform);
                collectibleHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;
                collectibleHolding.transform.localPosition = new Vector3(0, 1.43f, 0);
            }
        }


        if (trigger.gameObject.tag == "homeBase")
        {
            Debug.Log("Collision with home base");
            homeBase thisBase = trigger.gameObject.GetComponent<homeBase>();
            if (thisBase.inUse == false)
            {
                if (isHoldingCollectible == true)
                {
                    Debug.Log("All necessary conditions held");
                    thisBase.inUse = true;
                    collectibleHolding.transform.parent = null;
                    collectibleHolding.transform.SetParent(thisBase.transform);
                    collectibleHolding.GetComponent<SpriteRenderer>().sortingOrder = -1;
                    collectibleHolding.transform.localPosition = new Vector3(0, 0, 0);
                    //collectibleHolding.GetComponent<Collider2D>();
                    isHoldingCollectible = false;
                }
            }
        }
    }
}
