using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

    public bool unbreakable;
    private BlockCreator armOverMe;
    private GameObject armObjectOverMe;
    bool wasJustPlaced=true;
    void Start()
    {
        StartCoroutine(justPlaced());
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "drill" && !unbreakable)
        {
            var blockDestroyer = coll.gameObject.GetComponentInParent<DestroyBlocks>();
            if (blockDestroyer.drilling && !blockDestroyer.hasHitTank())
            {
                Destroy(gameObject);
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
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "wall" && wasJustPlaced && !unbreakable)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator justPlaced()
    {
        for(int i = 0; i< 2; i++)
        {
            yield return null;
        }
        wasJustPlaced = false;
    }
}
