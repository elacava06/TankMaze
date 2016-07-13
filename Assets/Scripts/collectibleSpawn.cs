using UnityEngine;
using System.Collections;

public class collectibleSpawn : MonoBehaviour
{

    public GameObject collectible;

    // Use this for initialization
    void Start()
    {
        spawnNewCollectible();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnNewCollectible()
    {
        GameObject newCollectible = Instantiate(collectible);
        newCollectible.transform.SetParent(transform);
        newCollectible.transform.localPosition = new Vector3(0, 0, 0);
    }
}
