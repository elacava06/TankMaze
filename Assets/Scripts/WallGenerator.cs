using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {
    public int width;
    public int height;
    public GameObject wallToGenerate;
    public float roundToThisInterval;
    public float xShift;
    public float yShift;
	// Use this for initialization
	void Start () {
        float newx = Mathf.Round(transform.position.x / roundToThisInterval) * roundToThisInterval + xShift;
        float newy = Mathf.Round(transform.position.y / roundToThisInterval) * roundToThisInterval + yShift;
        transform.position = new Vector3(newx, newy);
        float blockwidth = wallToGenerate.GetComponent<SpriteRenderer>().bounds.size.x;
	    for(int i = 0; i < width; i++)
        {
            for(int y =0; y<height; y++)
            {
                GameObject wall = Instantiate(wallToGenerate, transform.position + transform.rotation*(new Vector3(blockwidth * i, blockwidth * y)), Quaternion.identity) as GameObject;
                wall.transform.parent = transform;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
	}
}
