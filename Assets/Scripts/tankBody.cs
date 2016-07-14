using UnityEngine;
using System.Collections;

public class tankBody : MonoBehaviour
{
    //public variables
    
    //private variables
    private Rigidbody2D body;
    private GameObject collectibleHolding;
    private bool isHoldingCollectible = false;
    private tankInfo myTankInfo;


    // Called once at start:
    void Start()
    {
        myTankInfo = GetComponentInParent<tankInfo>();
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
                if (collectibleHolding.GetComponent<collectible>().claimedTeamNumber != myTankInfo.teamNumber)
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
            if (thisBase.inUse == false && myTankInfo.teamNumber == thisBase.teamNumber)
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
                    collectibleHolding.GetComponent<collectible>().claimedTeamNumber = myTankInfo.teamNumber;
                    isHoldingCollectible = false;
                }
            }
        }
    }
}
