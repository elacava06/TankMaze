using UnityEngine;
using System.Collections;

public class DrillDamage : MonoBehaviour {
    //EdgeCollider2D drillCollider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "drill")
        {
            Debug.Log("drills can sense touching!!!");
        }
    }
}
