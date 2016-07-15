using UnityEngine;
using System.Collections;

/*
 * Represents the point where a player will spawn
 */
public class PlayerSpawn : MonoBehaviour {

    public GameObject tank;

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
    }

    public void respawn()
    {

    }

}
