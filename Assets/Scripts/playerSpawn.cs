using UnityEngine;
using System.Collections;

/*
 * Represents the point where a player will spawn
 */
public class playerSpawn : MonoBehaviour {

    public GameObject tankBody;

	// Use this for initialization
	void Start () {
        Instantiate(tankBody, this.transform.position, new Quaternion(0, 0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
