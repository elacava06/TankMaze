using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

    public bool unbreakable;
    private BlockCreator armOverMe;
    private GameObject armObjectOverMe;
    bool wasJustPlaced = true;
    public int wallSize;
    public GameObject wallGenerator;
    public int lowestPossibleWallSize;
    public bool roundUnbreakables;
    void Start()
    {
        StartCoroutine(justPlaced());
        if (roundUnbreakables && unbreakable)
        {
            roundPosition();
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "drill" && !unbreakable)
        {
            var blockDestroyer = coll.gameObject.GetComponentInParent<DestroyBlocks>();
            if (blockDestroyer.drilling && !blockDestroyer.hasHitTank())
            {
                destroyWall();
            }
        }
        else if (coll.tag == "placer")
        {
            armObjectOverMe = coll.gameObject;
            armOverMe = armObjectOverMe.GetComponent<BlockCreator>();
            armOverMe.setOverWall(true);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "placer")
        {
            if (armOverMe != null)
            {
                armOverMe.setOverWall(false);
            }
        }
    }
    public void markClaimed(bool bol)
    {
        unbreakable = bol;
    }
    void OnDestroy()
    {
        if (armOverMe != null)
        {
            armOverMe.setOverWall(false);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(coll.gameObject.tag);
        if (wasJustPlaced && !unbreakable)
        {
            if (coll.gameObject.tag == "wall" || coll.gameObject.tag == "homeBase" || coll.gameObject.tag == "unbreakableWall")
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator justPlaced()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return null;
        }
        wasJustPlaced = false;
    }

    public void destroyWall()
    {
        if (wallSize <= lowestPossibleWallSize)
        {
            Destroy(gameObject);
        }
        else
        {
            breakIntoSmallerWalls();
            wallSize--;
        }
    }

    void breakIntoSmallerWalls()
    {
        Destroy(GetComponent<Renderer>());
        Destroy(GetComponent<Collider2D>());
        //Vector3 bottomLeftCorner = transform.position - new Vector3((GetComponent<Renderer>().bounds.size.x / 2), (GetComponent<Renderer>().bounds.size.y / 2), 0);
        GameObject smallerWallGenerator = Instantiate(wallGenerator, transform.position, transform.rotation) as GameObject;
        smallerWallGenerator.transform.SetParent(transform);
        smallerWallGenerator.transform.localPosition = (-1 * (new Vector3((GetComponent<Renderer>().bounds.size.x / (4*transform.localScale.x)), (GetComponent<Renderer>().bounds.size.y / (4*transform.localScale.y)), 0)));
        smallerWallGenerator.GetComponent<WallGenerator>().wallSize = wallSize - 1;
        smallerWallGenerator.GetComponent<WallGenerator>().roundPosition = false;
        smallerWallGenerator.GetComponent<WallGenerator>().width = 2;
        smallerWallGenerator.GetComponent<WallGenerator>().height = 2;
        smallerWallGenerator.GetComponent<WallGenerator>().lowestPossibleWallSize = lowestPossibleWallSize;
        //Destroy(smallerWallGenerator.GetComponent<Rigidbody2D>());
        Destroy(this);
    }
    void roundPosition()
    {
        float roundToThisInterval = gameObject.GetComponent<Renderer>().bounds.size.x;
        float newx = Mathf.Round(transform.position.x / roundToThisInterval) * roundToThisInterval;
        float newy = Mathf.Round(transform.position.y / roundToThisInterval) * roundToThisInterval;
        transform.position = new Vector3(newx, newy);
    }
}
