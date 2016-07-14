using UnityEngine;
using System.Collections;

/*
 * Represents the turret on top of the tank
 */
public class Turret : MonoBehaviour {

    public float turnSpeed;
    public GameObject shot;
    private Rigidbody2D shotBody;
    public float shotSpeed;
    public float fireRate;
    private float nextFire;
    private tankInfo myTankInfo;

	// Use this for initialization
	void Start () {
        myTankInfo = GetComponentInParent<tankInfo>();
    }
	
	// Update is called once per frame
	void Update () {
        turnTurret();
        shoot();
	}

    /*
     * Turns the turret
     * The turret will turn counterclockwise when a is held
     * The turret will turn clockwise when d is held
     */
    public void turnTurret()
    {
        Vector3 direction = new Vector3(Input.GetAxis("turret"), 0);
        this.transform.Rotate(Vector3.forward, direction.x * turnSpeed);
    }

    /*
     * Shoots a projectile from the turret
     * The projectile will fly off in the direction the turret is facing
     * The projectile will fire when the space bar is pressed
     */
     public void shoot()
    {
        if (Input.GetAxis("shoot") > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shotClone = Instantiate(shot, this.transform.Find("shotSpawn").transform.position, this.transform.rotation) as GameObject;
            shotClone.GetComponent<Shot>().teamNumber = myTankInfo.teamNumber;
            float xDirection = -Mathf.Sin(this.transform.eulerAngles.z * Mathf.Deg2Rad);
            float yDirection = Mathf.Cos(this.transform.eulerAngles.z * Mathf.Deg2Rad);
            shotBody = shotClone.GetComponent<Rigidbody2D>();
            shotBody.velocity = new Vector2(xDirection, yDirection) * shotSpeed;
        }
    }
}
