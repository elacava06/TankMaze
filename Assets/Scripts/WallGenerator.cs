﻿using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {
    public int width;
    public int height;
    public GameObject wallToGenerate;
    public GameObject smallWall;
    public GameObject mediumWall;
    public GameObject bigWall;
    public GameObject reallyBigWall;
    public GameObject unbreakableWall;
    public bool roundPosition;
    public bool dynamicRounding=false;
    public float roundToThisInterval;
    public float xShift;
    public float yShift;
    public int wallSize;
    public int lowestPossibleWallSize;
    private GameObject wallParent;
	// Use this for initialization
	void Start () {
        //if (transform.parent != null)
        //{
        //    Destroy(gameObject.GetComponent<Rigidbody2D>());
        //}

        wallParent = GameObject.FindGameObjectWithTag("wallParent");

        if (wallSize == 4)
        {
            wallToGenerate = reallyBigWall;
        }
        else if (wallSize == 3)
        {
            wallToGenerate = bigWall;
        }
        else if (wallSize == 2)
        {
            wallToGenerate = mediumWall;
        }
        else if (wallSize == 1)
        {
            wallToGenerate = smallWall;
        }
        else if (wallSize == -1)
        {
            wallToGenerate = unbreakableWall;
        }
        else
        {
            Debug.Log("wallSize is not between 1 and 4");
        }
        if (dynamicRounding)
        {
            roundToThisInterval = wallToGenerate.GetComponent<Renderer>().bounds.size.x;
        }
        float newx = Mathf.Round(transform.position.x / roundToThisInterval) * roundToThisInterval + xShift;
        float newy = Mathf.Round(transform.position.y / roundToThisInterval) * roundToThisInterval + yShift;
        SpriteRenderer image = GetComponent<SpriteRenderer>();
        if (image != null)
        {
            image.sprite = null;
        }
        if (roundPosition)
        {
            transform.position = new Vector3(newx, newy);
        }
        float blockwidth = wallToGenerate.GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 0; i < width; i++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject wall = Instantiate(wallToGenerate, transform.position + transform.rotation * (new Vector3(blockwidth * i, blockwidth * y)), Quaternion.identity) as GameObject;
                wall.transform.parent = wallParent.transform;
                wall.GetComponent<Wall>().lowestPossibleWallSize = lowestPossibleWallSize;
                Destroy(wall.GetComponent<Rigidbody2D>());
            }
        }
        Destroy(gameObject);
	}
}
