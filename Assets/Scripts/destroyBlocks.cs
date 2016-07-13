﻿using UnityEngine;
using System.Collections;

public class destroyBlocks : MonoBehaviour {

    public float rotationSpeed;
    public float drillRange;
    public float drillTime;
    public float drillCooldown;
    private bool drillingCooldown=false;
    private bool drilling=false;
    // Use this for initialization
    private Transform drillHead;
    public Vector3 originalPosition;

    void Start () {
        
        drillHead = transform.GetChild(0);
        originalPosition = drillHead.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        incrementRotation();
        if(Input.GetAxis("drill") !=0 && !drillingCooldown)
        {
            StartCoroutine(drill());
        }
	}

    void incrementRotation()
    {
        float change = Input.GetAxis("drillMovement");
        transform.Rotate(Vector3.forward, -change * rotationSpeed);
    }

    IEnumerator drill()
    {
        Debug.Log("drill called");
        drilling = true;
        drillingCooldown = true;
        
        Debug.Log(originalPosition);
        float fireTime = Time.time;
        while(Time.time<(fireTime+ drillTime))
        {
            drillHead.localPosition += Vector3.up * drillRange / drillTime;
            yield return null;
        }
        drilling = false;


        fireTime = Time.time;
        while (Time.time < (fireTime + drillCooldown))
        {
            drillHead.localPosition -= Vector3.up * drillRange / drillCooldown;
            yield return null;
        }
        //transform.Translate(transform.rotation * Vector3.up * drillRange);
        drillHead.localPosition = originalPosition;
        drillingCooldown = false;
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("trigger happened");
        if (drilling)
        {
            if (coll.gameObject.tag == "wall")
            {
                Destroy(coll.gameObject);
            }
        }
    }
}
