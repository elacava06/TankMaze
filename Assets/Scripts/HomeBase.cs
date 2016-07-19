using UnityEngine;
using System.Collections;

public class HomeBase : MonoBehaviour
{

    public bool inUse = false;
    public int teamNumber;

    // Use this for initialization
    void Start()
    {
        if (teamNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;

        }
        else if (teamNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Gets the team number of the home base
     * @return an int that is the team number of the base
     */
    public int getTeamNumber()
    {
        return this.teamNumber;
    }
}
