﻿using UnityEngine;
using System.Collections;


public enum characterClass { miner, shooter, everything };  //declaring outside, so it can be used by entire assembly;


public class PlayerSpawn : MonoBehaviour {
 /*
 * Represents the point where a player will spawn
 */
    public GameObject tank;
    
    public characterClass myClass;
	// Use this for initialization
	void Start () {
        spawnTank();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
     * Assigns the spawning tank a team number
     * The team number will be the same team number as the base
     */
    public void spawnTank()
    {
        GameObject tankClone = Instantiate(tank, this.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        int teamNumber = this.GetComponentInParent<HomeBase>().teamNumber;
        tankClone.GetComponent<TankInfo>().teamNumber = teamNumber;
        tankClone.GetComponent<TankInitiate>().setClass(myClass); 
    }
}