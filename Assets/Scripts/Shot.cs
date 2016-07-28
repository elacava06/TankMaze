using UnityEngine;
using System.Collections;

/*
 * Represents a shot fired by the turret
 */
public class Shot : MonoBehaviour {

    public int SHOT_DAMAGE;
    public int teamNumber;
    public bool breaksWalls;
    public float wallDamage = 1f;
    public bool destroyedByOwnShield;

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
        else if(other.tag == "shield")
        {
            Shield thisShield = other.gameObject.GetComponentInParent<Shield>();
            if (thisShield.teamNumber == teamNumber && destroyedByOwnShield)
            {
                Destroy(this.gameObject);
            }
            else if (thisShield.shieldHealth != 0) {
                thisShield.takeDamage();
                Destroy(this.gameObject);
            }
            //Debug.Log("i think it workeddd?");
        }
        else if (other.tag == "wall" && breaksWalls)
        {

            other.GetComponent<Wall>().damageWall(wallDamage);
            Destroy(this.gameObject);
        }
        else if (!(other.tag == "drill" || other.tag == "tankBody" || other.tag == "collectible" || other.tag == "placer" ))
        {
            Destroy(this.gameObject);
        }
    }

    /*
     * Damages the tank that the shot hits
     */
    void damageTank(Transform other)
    {
        other.GetComponentInChildren<HealthBar>().loseHealth(SHOT_DAMAGE);
        other.GetComponentInChildren<TankBody>().loseHealth(SHOT_DAMAGE);
    }
}
