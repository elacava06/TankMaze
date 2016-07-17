using UnityEngine;
using System.Collections;

/*
 * Creates the tank components
 */
public class TankInitiate : MonoBehaviour {

    public GameObject body;
    public GameObject turret;
    public float turretOffset;
    public GameObject arm;
    public float armOffset;
    public GameObject drill;
    public GameObject shield;
    public GameObject healthUI;
    public float healthUIDistance;

    private characterClass myClass;

    // Use this for initialization
    void Start()
    {
        GameObject myBody = Instantiate(body, transform.position, Quaternion.identity) as GameObject;
        myBody.transform.SetParent(transform);
        GameObject myHealthUI = Instantiate(healthUI, new Vector3(transform.position.x, transform.position.y - healthUIDistance), Quaternion.identity) as GameObject;
        myHealthUI.transform.SetParent(transform);
        if (myClass == characterClass.miner)
        {
            GameObject myArm = Instantiate(arm, transform.position + transform.rotation * (new Vector3(0, armOffset)), Quaternion.identity) as GameObject;
            myArm.transform.SetParent(transform);
            GameObject myDrill = Instantiate(drill, transform.position, Quaternion.identity) as GameObject;
            myDrill.transform.SetParent(transform);
        }
        else if (myClass == characterClass.shooter)
        {
            GameObject myTurret = Instantiate(turret, transform.position + transform.rotation * (new Vector3(0, turretOffset)), Quaternion.identity) as GameObject;
            myTurret.transform.SetParent(transform);
            GameObject myShield = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
            myShield.transform.SetParent(transform);
        }
        
       
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setClass(characterClass input)
    {
        myClass = input;
    }
}
