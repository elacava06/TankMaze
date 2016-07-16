using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

    public bool unbreakable;
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "drill" && !unbreakable)
        {
            if (coll.gameObject.GetComponentInParent<DestroyBlocks>().drilling)
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
}
