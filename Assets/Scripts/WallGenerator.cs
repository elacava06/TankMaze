using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {
    public int width;
    public int height;
    public GameObject wallToGenerate;
	// Use this for initialization
	void Start () {
        float blockwidth = wallToGenerate.GetComponent<SpriteRenderer>().bounds.size.x;
	    for(int i = 0; i < width; i++)
        {
            for(int y =0; y<height; y++)
            {
                GameObject wall = Instantiate(wallToGenerate, transform.position + new Vector3(blockwidth * i, blockwidth * y), Quaternion.identity) as GameObject;
                wall.transform.parent = transform;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
