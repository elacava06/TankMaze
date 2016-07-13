using UnityEngine;
using System.Collections;

public class tankBody : MonoBehaviour
{
    //public variables
    public float turnSpeed;
    public float movementSpeed;
    public int teamNumber;

    //private variables
    private Rigidbody2D body;
    private GameObject collectibleHolding;
    private bool isHoldingCollectible = false;


    // Called once at start:
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        if (teamNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (teamNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
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
                collectibleHolding = trigger.gameObject;

                // Checks to make sure the collectible is not already claimed by your team
                if (collectibleHolding.GetComponent<collectible>().claimedTeamNumber != teamNumber)
                {
                    //Puts collectible on the hood and unclaims collectible
                    Debug.Log("parent: " + collectibleHolding.transform.parent);
                    if (collectibleHolding.transform.parent.gameObject.tag == "collectibleSpawn")
                    {
                        collectibleHolding.transform.parent.gameObject.GetComponent<collectibleSpawn>().spawnNewCollectible();
                    }
                    isHoldingCollectible = true;
                    collectibleHolding.transform.parent = null;
                    collectibleHolding.transform.SetParent(transform);
                    collectibleHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    collectibleHolding.transform.localPosition = new Vector3(0, 1.43f, 0);
                    collectibleHolding.GetComponent<collectible>().claimedTeamNumber = -1;
                }
            }
        }


        if (trigger.gameObject.tag == "homeBase")
        {
            homeBase thisBase = trigger.gameObject.GetComponent<homeBase>();

            // Checks to make sure the base belongs to your team and isn't already claimed
            if (thisBase.inUse == false && teamNumber == thisBase.teamNumber)
            {
                // Checks to make sure you are holding a collectible
                if (isHoldingCollectible == true)
                {
                    // Sets the collectible on the base, claims base, claims collectible
                    thisBase.inUse = true;
                    collectibleHolding.transform.parent = null;
                    collectibleHolding.transform.SetParent(thisBase.transform);
                    collectibleHolding.GetComponent<SpriteRenderer>().sortingOrder = -1;
                    collectibleHolding.transform.localPosition = new Vector3(0, 0, 0);
                    collectibleHolding.GetComponent<collectible>().claimedTeamNumber = teamNumber;
                    isHoldingCollectible = false;
                }
            }
        }
    }
}
