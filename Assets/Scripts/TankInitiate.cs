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

    // Use this for initialization
    void Start()
    {
        GameObject myBody = Instantiate(body, transform.position, Quaternion.identity) as GameObject;
        GameObject myTurret = Instantiate(turret, transform.position + transform.rotation*(new Vector3(0, turretOffset)), Quaternion.identity) as GameObject;
        GameObject myArm = Instantiate(arm, transform.position + transform.rotation * (new Vector3(0, armOffset)), Quaternion.identity) as GameObject;
        GameObject myDrill = Instantiate(drill, transform.position, Quaternion.identity) as GameObject;
        GameObject myShield = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
        GameObject myHealthUI = Instantiate(healthUI, new Vector3(transform.position.x, transform.position.y - healthUIDistance), Quaternion.identity) as GameObject;

        myBody.transform.SetParent(transform);
        myTurret.transform.SetParent(transform);
        myArm.transform.SetParent(transform);
        myDrill.transform.SetParent(transform);
        myShield.transform.SetParent(transform);
        myHealthUI.transform.SetParent(transform);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
