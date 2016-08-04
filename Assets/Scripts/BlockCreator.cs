using UnityEngine;
using System.Collections;

public class BlockCreator : MonoBehaviour
{
    private string axisName;
    public float coolDown;
    public GameObject wallSpawner;
    public int width;
    public int height;
    public GameObject wallToGenerate;
    private WallGenerator generator;
    private int controllerNumber;
    public float roundToThisInterval;
    private float widthOfSprite;
    private GameObject wallParent;

    private bool isOverWall;
    private bool coolDownDone = true;
    public GameObject gameStateManager;
    private GameState gameManager;

    void Start()
    {
        gameStateManager = GameObject.Find("GameManager");
        gameManager = gameStateManager.GetComponent<GameState>();
        wallParent = GameObject.FindGameObjectWithTag("wallParent");
        widthOfSprite = wallToGenerate.GetComponent<Renderer>().bounds.size.x;
        roundToThisInterval = widthOfSprite;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState == GameState.gameState.play)
        {
            if (Input.GetAxis(axisName) > 0 && coolDownDone)
            {
                if (checkIfEmpty())
                {
                    coolDownDone = false;
                    Invoke("setCoolDown", coolDown);
                    float angleToSpawn = Mathf.Round(transform.rotation.eulerAngles.z / 90.0f) * 90.0f;
                    GameObject square = Instantiate(wallSpawner, transform.position, Quaternion.Euler(new Vector3(0, 0, angleToSpawn))) as GameObject;
                    generator = square.GetComponent<WallGenerator>();
                    generator.transform.SetParent(wallParent.transform);
                    generator.wallToGenerate = wallToGenerate;
                    generator.width = width;
                    generator.height = height;
                    generator.roundToThisInterval = roundToThisInterval;
                }
            }
        }

    }
    void setCoolDown()
    {
        coolDownDone = true;
    }
    private bool checkIfEmpty()
    {

        return !isOverWall;
    }

    public void setOverWall(bool setting)
    {
        isOverWall = setting;
    }

    public void setControllerNumber(int number)
    {
        controllerNumber = number;
        axisName = "drill" + controllerNumber;
    }

}