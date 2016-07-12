using UnityEngine;
using System.Collections;

/*
 * Represents the turret on top of the tank
 */
public class Turret : MonoBehaviour {

    public float turnSpeed;

	// Use this for initialization
	void Start () {
        turnSpeed = 60;
	}
	
	// Update is called once per frame
	void Update () {
        turnTurret();
	}

    void turnTurret()
    {
        Vector3 direction = new Vector3(Input.GetAxis("turret"), 0);
        this.transform.Rotate(Vector3.forward, direction * turnSpeed);
    }
}
