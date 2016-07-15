using UnityEngine;
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
        if (other.tag == "tankBody")
        {
            if (other.GetComponentInParent<TankInfo>().teamNumber != teamNumber)
            {
                damageTank(other);
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "wall" && breaksWalls)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (!(other.tag == "drill" || other.tag == "tank" || other.tag == "collectible"))
        {
            Destroy(this.gameObject);
        }
    }

    /*
     * Damages the tank that the shot hits
     */
    void damageTank(Collider2D other)
    {
        other.GetComponent<TankBody>().loseHealth(SHOT_DAMAGE);
        other.transform.parent.GetComponentInChildren<HealthBar>().loseHealth(SHOT_DAMAGE);
    }
}
