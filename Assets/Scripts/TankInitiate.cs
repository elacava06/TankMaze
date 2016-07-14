﻿using UnityEngine;
using System.Collections;

public class TankInitiate : MonoBehaviour {

    public GameObject body;
    public GameObject turret;
    public GameObject drill;
    public GameObject shield;

    // Use this for initialization
    void Start()
    {
        GameObject myBody = Instantiate(body, transform.position, Quaternion.identity) as GameObject;
        GameObject myTurret = Instantiate(turret, transform.position, Quaternion.identity) as GameObject;
        GameObject myDrill = Instantiate(drill, transform.position, Quaternion.identity) as GameObject;
        GameObject myShield = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;

        myBody.transform.SetParent(transform);
        myTurret.transform.SetParent(transform);
        myDrill.transform.SetParent(transform);
        myShield.transform.SetParent(transform);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}