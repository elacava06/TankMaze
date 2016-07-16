﻿using UnityEngine;
using System.Collections;

/*
 * Represents a shot fired by the turret
 */
public class Shot : MonoBehaviour {

    public int SHOT_DAMAGE;
    public int teamNumber;
    public bool breaksWalls;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "tank")
        {
            if (other.GetComponent<TankInfo>().teamNumber != teamNumber)
            {
                damageTank(other.transform);
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "wall" && breaksWalls)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (!(other.tag == "drill" || other.tag == "tankBody" || other.tag == "collectible" || other.tag == "placer"))
        {
            Destroy(this.gameObject);
        }
    }

    /*
     * Damages the tank that the shot hits
     */
    void damageTank(Transform other)
    {
        other.GetComponentInChildren<TankBody>().loseHealth(SHOT_DAMAGE);
        other.GetComponentInChildren<HealthBar>().loseHealth(SHOT_DAMAGE);
    }
}
