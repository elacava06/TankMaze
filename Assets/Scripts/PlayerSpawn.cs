using UnityEngine;
using System.Collections;


public enum characterClass { miner, shooter, everything };  //declaring outside, so it can be used by entire assembly;


public class PlayerSpawn : MonoBehaviour {
    /*
    * Represents the point where a player will spawn
    */
    public GameObject tank;
    public int teamNumber;

    public int[] controllerNumbers;

    public characterClass myClass;
	// Use this for initialization
	void Start () {
        spawnTank();
        myClass = characterClass.miner;
	}

    /*
     * Assigns the spawning tank a team number
     * The team number will be the same team number as the base
     */
    public void spawnTank()
    {
        GameObject tankClone = Instantiate(tank, transform.position, transform.rotation) as GameObject;
        tankClone.GetComponent<TankInfo>().setTeamNumber(teamNumber);
        tankClone.GetComponent<TankInitiate>().setClass(myClass);
        tankClone.GetComponent<TankInfo>().setControllerNumbers(controllerNumbers);
    }
}