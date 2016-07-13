using UnityEngine;
using System.Collections;

/*
 * Represents a shot fired by the turret
 */
public class Shot : MonoBehaviour {

    public int teamNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "tankBody")
        {
            if (other.GetComponent<tankBody>().teamNumber != teamNumber)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
