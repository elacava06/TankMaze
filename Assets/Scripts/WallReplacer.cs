using UnityEngine;
using System.Collections;

public class WallReplacer : MonoBehaviour {
    public GameObject wall;
	// Use this for initialization
	void Start () {
	    foreach(Transform wallToReplace in GetComponentsInChildren<Transform>())
        {
            if (wallToReplace != transform)
            {
                var newWall = Instantiate(wall, wallToReplace.position, wallToReplace.rotation) as GameObject;
                newWall.transform.parent = transform;
                Destroy(wallToReplace.gameObject);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
