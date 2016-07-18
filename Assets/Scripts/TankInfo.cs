using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Represents a tank
 */
public class TankInfo : MonoBehaviour {

    public int teamNumber;
    private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
        if (teamNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (teamNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        spawnPoint = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
     * Gets the point where the tank was spawned
     * @return Vector3 that is the position of the spawn point
     */
    public Vector3 getSpawnPoint()
    {
        return this.spawnPoint;
    }

}
