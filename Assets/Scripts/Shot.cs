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

    void Start()
    {
        if (GameControl.control.getUseGameControl())
        {
            this.setDestroyedByOwnShield(GameControl.control.getDestroyedByOwnShield());
            if (!GameControl.control.getDestroyWalls()) { this.setWallDamage(0); };
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "tank")
        {
            if (other.GetComponent<TankInfo>().teamNumber != teamNumber)
            {
                damageTank(other.transform);
                Destroy();
            }
        }
        else if(other.tag == "shield")
        {
            Shield thisShield = other.gameObject.GetComponentInParent<Shield>();
            if (thisShield.teamNumber == teamNumber && this.getDestroyedByOwnShield())
            {
                Destroy();
            }
            else if (thisShield.shieldHealth != 0) {
                thisShield.takeDamage();
                Destroy();
            }
            //Debug.Log("i think it workeddd?");
        }
        else if (other.tag == "wall" && breaksWalls)
        {
            //other.GetComponent<Wall>().destroyWall();
            other.GetComponent<Wall>().damageWall(this.getWallDamage());
            Destroy();
        }
        else if (!(other.tag == "drill" || other.tag == "tankBody" || other.tag == "collectible" || other.tag == "placer" ))
        {
            Destroy();
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

    /*
     * Deactivates this shot
     */
    void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    /*
     * Sets whether or not shots are destroyed on their tank's shield
     * @param value the value that will determine if shots are destroyed on their shield
     */
    public void setDestroyedByOwnShield(bool value)
    {
        destroyedByOwnShield = value;
    }

    /*
     * Gets whether or not shots are destroyed on their tank's shield
     * @return bool true if shots are destroyed on their shield, false otherwise
     */
    public bool getDestroyedByOwnShield()
    {
        return destroyedByOwnShield;
    }

    /*
     * Gets how much damage shots do to walls
     * @return float the amount of damage shots do to walls
     */
    public float getWallDamage()
    {
        return wallDamage;
    }

    /*
     * Sets how much damage shots do to walls
     * @param amount the amount of damage shots will do to walls
     */
    public void setWallDamage(float amount)
    {
        wallDamage = amount;
    }
}
