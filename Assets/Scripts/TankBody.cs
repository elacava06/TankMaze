﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Represents the actual body of the tank
 */
public class TankBody : MonoBehaviour
{
    //public variables
    public int MAX_HEALTH;
    
    //private variables
    private Rigidbody2D body;
    private GameObject collectibleHolding;
    private bool isHoldingCollectible = false;
    private TankInfo myTankInfo;
    private int currentHealth;

    // Called once at start:
    void Start()
    {
        currentHealth = MAX_HEALTH;
        myTankInfo = GetComponentInParent<TankInfo>();
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
                if (collectibleHolding.GetComponent<Collectible>().claimedTeamNumber != myTankInfo.teamNumber)
                {
                    //Puts collectible on the hood and unclaims collectible
                    if (collectibleHolding.transform.parent != null)
                    {
                        if (collectibleHolding.transform.parent.gameObject.tag == "collectibleSpawn")
                        {
                            collectibleHolding.transform.parent.gameObject.GetComponent<CollectibleSpawn>().spawnNewCollectible();
                        }
                        if (collectibleHolding.transform.parent.gameObject.tag == "homeBase")
                        {
                            collectibleHolding.transform.parent.gameObject.GetComponent<HomeBase>().inUse = false;
                        }
                    }
                    isHoldingCollectible = true;
                    collectibleHolding.transform.parent = null;
                    collectibleHolding.transform.SetParent(transform);
                    collectibleHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    collectibleHolding.transform.localPosition = new Vector3(0, 0.26f, 0);
                    collectibleHolding.transform.localRotation = Quaternion.identity;
                    collectibleHolding.GetComponent<Collectible>().claimedTeamNumber = -1;
                }
            }
        }


        if (trigger.gameObject.tag == "homeBase")
        {
            HomeBase thisBase = trigger.gameObject.GetComponent<HomeBase>();

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
                    collectibleHolding.transform.localRotation = Quaternion.identity;
                    collectibleHolding.GetComponent<Collectible>().claimedTeamNumber = myTankInfo.teamNumber;
                    isHoldingCollectible = false;
                }
            }
        }
    }

    /*
     * Lowers the players health by amount
     * Destroys the tank if health reaches 0
     */
    public void loseHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth == 0)
        {
            respawn();
        }
    }

    /*
     * Spawns the player back at the spawn point
     */
    private void respawn()
    {
        this.transform.parent.transform.position = this.transform.GetComponentInParent<TankInfo>().getSpawnPoint();
        this.transform.parent.transform.rotation = Quaternion.identity;
        fullHealth();
    }

    /*
     * Restores the tank back to full health
     */
    private void fullHealth()
    {
        this.transform.parent.GetComponentInChildren<HealthBar>().fullHealth();
        currentHealth = MAX_HEALTH;
    }
}
