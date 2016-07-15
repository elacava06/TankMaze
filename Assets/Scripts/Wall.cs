using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "drill")
        {
            if (coll.gameObject.GetComponentInParent<DestroyBlocks>().drilling)
            {
                Destroy(gameObject);
            }
        }
    }
}
