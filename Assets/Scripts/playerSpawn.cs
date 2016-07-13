using UnityEngine;
using System.Collections;

/*
 * Represents the point where a player will spawn
 */
public class playerSpawn : MonoBehaviour {

    public GameObject tankBody;

	// Use this for initialization
	void Start () {
        getTeamNumber();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
     * Assigns the spawning tank a team number
     * The team number will be the same team number as the base
     */
    void getTeamNumber()
    {
        GameObject tankBodyClone = Instantiate(tankBody, this.transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        int teamNumber = this.GetComponentInParent<homeBase>().teamNumber;
        tankBodyClone.GetComponent<tankBody>().teamNumber = teamNumber;
    }
}
