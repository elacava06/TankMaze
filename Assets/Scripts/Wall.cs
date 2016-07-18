using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

    public bool unbreakable;
    void Start()
    {
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
            coll.GetComponent<BlockCreator>().setOverWall(true);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "placer")
        {
            coll.GetComponent<BlockCreator>().setOverWall(false);
        }
    }
    public void markClaimed(bool bol)
    {
        unbreakable = bol;
    }
}
