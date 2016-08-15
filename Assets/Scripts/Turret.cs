using UnityEngine;
using System.Collections;

/*
 * Represents the turret on top of the tank
 */
public class Turret : MonoBehaviour
{

    public GameObject shot;
    private Rigidbody2D shotBody;
    public float shotSpeed;
    public float fireRate;
    private float nextFire;
    private TankInfo myTankInfo;
    private int controllerNumber;
    public string shootAxis;

    public GameObject gameStateManager;
    private GameState gameManager;

    void Start()
    {
        gameStateManager = GameObject.Find("GameManager");
        gameManager = gameStateManager.GetComponent<GameState>();
        myTankInfo = GetComponentInParent<TankInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState == GameState.gameState.play)
        {
            shoot();
        }
    }

    
    /*
     * Shoots a projectile from the turret
     * The projectile will fly off in the direction the turret is facing
     * The projectile will fire when the space bar is pressed
     */
    public void shoot()
    {
        if (Input.GetAxis(shootAxis) > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shotClone = BulletPoolScript.current.GetPooledObject();
            shotClone.transform.position = this.transform.Find("shotSpawn").transform.position;
            shotClone.transform.rotation = this.transform.rotation;
            shotClone.GetComponent<Shot>().teamNumber = myTankInfo.teamNumber;
            shotClone.SetActive(true);
            float xDirection = -Mathf.Sin(this.transform.eulerAngles.z * Mathf.Deg2Rad);
            float yDirection = Mathf.Cos(this.transform.eulerAngles.z * Mathf.Deg2Rad);
            shotBody = shotClone.GetComponent<Rigidbody2D>();
            shotBody.velocity = new Vector2(xDirection, yDirection) * shotSpeed;
        }
    }

    public void setControllerNumber(int number)
    {
        controllerNumber = number;
        shootAxis = "drill" + controllerNumber;
    }
}
