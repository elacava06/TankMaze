using UnityEngine;
using System.Collections;

public class BlockCreator : MonoBehaviour
{
    public string axisName;
    public float coolDown;
    public GameObject wallSpawner;
    public int width;
    public int height;
    public GameObject wallToGenerate;
    private WallGenerator generator;
    private float fireTime;
    private int controllerNumber;
    public float roundToThisInterval;
    private float widthOfSprite;

    private bool isOverWall;
    // Use this for initialization
    void Start()
    {
        widthOfSprite = wallToGenerate.GetComponent<Renderer>().bounds.size.x * width;
        //roundToThisInterval = widthOfSprite;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(axisName) > 0 && Time.time > fireTime + coolDown)
        {
            if (checkIfEmpty())
            {
                fireTime = Time.time;
                float angleToSpawn = Mathf.Round(transform.rotation.eulerAngles.z / 90.0f) * 90.0f;
                GameObject square = Instantiate(wallSpawner, transform.position, Quaternion.Euler(new Vector3(0,0,angleToSpawn))) as GameObject;
                generator = square.GetComponent<WallGenerator>();
                generator.wallToGenerate = wallToGenerate;
                generator.width = width;
                generator.height = height;
                generator.roundToThisInterval = roundToThisInterval;
            }
        }

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
        axisName = axisName + controllerNumber;
    }

}