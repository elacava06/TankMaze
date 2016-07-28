using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Creates a pool of shots to shoot from
 */
public class BulletPoolScript : MonoBehaviour {

    public static BulletPoolScript current;
    public GameObject pooledObject;
    public int pooledAmount;
    private List<GameObject> pooledObjects;
    private int poolPointer = 0;

    void Awake()
    {
        current = this;
    }

	// Use this for initialization
	void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}
	
    /*
     * Returns an unused pooled object from pooledObjects
     */
	public GameObject GetPooledObject()
    {
        if (poolPointer >= pooledAmount) { poolPointer = 0; };
        poolPointer += 1;
        return pooledObjects[poolPointer - 1];
    }
}
