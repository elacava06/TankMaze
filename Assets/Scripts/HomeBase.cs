using UnityEngine;
using System.Collections;

public class HomeBase : MonoBehaviour
{

    public bool inUse = false;
    public int teamNumber;
    public GameObject playerSpawn;
    public int[] controllerNumbers;

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

        GameObject myPlayerSpawn = Instantiate(playerSpawn, transform.position, Quaternion.identity) as GameObject;
        myPlayerSpawn.transform.SetParent(transform);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public int[] getControllerNumbers()
    {
        return controllerNumbers;
    }
}
