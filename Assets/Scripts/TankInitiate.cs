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
    private TankInfo myTankInfo;
    private int[] controllerNumbers;

    private characterClass myClass;

    // Use this for initialization
    void Start()
    {
        myTankInfo = GetComponent<TankInfo>();
        controllerNumbers = myTankInfo.getControllerNumbers();

        GetComponent<TankMovement>().setControllerNumber(controllerNumbers[0]);

        GameObject myBody = Instantiate(body, transform.position, transform.rotation) as GameObject;
        myBody.transform.SetParent(transform);

        GameObject myHealthUI = Instantiate(healthUI, new Vector3(transform.position.x, transform.position.y - healthUIDistance), Quaternion.identity) as GameObject;
        myHealthUI.transform.SetParent(transform);

        if (myClass == characterClass.miner || myClass == characterClass.everything)
        {
            GameObject myArm = Instantiate(arm, transform.position + transform.rotation * (new Vector3(0, armOffset)), transform.rotation) as GameObject;
            myArm.transform.SetParent(transform);
            myArm.GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[1]);
            myArm.GetComponentInChildren<BlockCreator>().setControllerNumber(controllerNumbers[1]);

            GameObject myDrill = Instantiate(drill, transform.position, transform.rotation) as GameObject;
            myDrill.transform.SetParent(transform);
            myDrill.GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[2]);
            myDrill.GetComponent<DestroyBlocks>().setControllerNumber(controllerNumbers[2]);
        }
        if (myClass == characterClass.shooter || myClass == characterClass.everything)
        {
            GameObject myTurret = Instantiate(turret, transform.position + transform.rotation * (new Vector3(0, turretOffset)), transform.rotation) as GameObject;
            myTurret.transform.SetParent(transform);
            myTurret.GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[1]);
            myTurret.GetComponent<Turret>().setControllerNumber(controllerNumbers[1]);

            GameObject myShield = Instantiate(shield, transform.position, transform.rotation) as GameObject;
            myShield.transform.SetParent(transform);
            myShield.GetComponent<CircleRotation>().setControllerNumber(controllerNumbers[2]);
        }
        
       
        

    }
    public void setClass(characterClass input)
    {
        myClass = input;
    }
}
