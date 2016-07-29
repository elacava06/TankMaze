using UnityEngine;
using System.Collections;

public class CollectibleSpawn : MonoBehaviour
{

    public GameObject collectible;
    public bool collectiblesRespawn;

    // Use this for initialization
    void Start()
    {
        spawnNewCollectible();
    }

    public void spawnNewCollectible()
    {
        if (collectiblesRespawn)
        {
            GameObject newCollectible = Instantiate(collectible);
            newCollectible.transform.SetParent(transform);
            newCollectible.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
