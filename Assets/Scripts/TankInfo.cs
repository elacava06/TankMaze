using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Represents a tank
 */
public class TankInfo : MonoBehaviour
{
    public Color[] teamColors;
    public int teamNumber;
    private Vector3 spawnPoint;
    private int[] controllerNumbers;

    // Use this for initialization
    void Start()
    {

        if (teamNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = teamColors[teamNumber - 1];
            //transform.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            //transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (teamNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = teamColors[teamNumber - 1];
            //transform.Find("turret(Clone)").Find("turretImage").gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = Color.blue;
        }
        spawnPoint = this.transform.position;
    }

    /*
     * Sets the team number of the tank
     * @param number the the number that will become the team number
     */
    public void setTeamNumber(int number)
    {
        teamNumber = number;
    }

    /*
     * Gets the point where the tank was spawned
     * @return Vector3 that is the position of the spawn point
     */
    public Vector3 getSpawnPoint()
    {
        return this.spawnPoint;
    }

    public int[] getControllerNumbers()
    {
        return this.controllerNumbers;
    }

    public void setControllerNumbers(int[] numbers)
    {
        controllerNumbers = numbers;
    }

}
