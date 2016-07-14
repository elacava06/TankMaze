using UnityEngine;
using System.Collections;

/*
 * Represents the health bar UI
 */
public class HealthBar : MonoBehaviour {

    private Quaternion rotation;
    private float distance;
    private GameObject parent;

	// Use this for initialization
	void Awake () {
        rotation = this.transform.rotation;
        parent = this.transform.parent.gameObject;
        distance = Vector3.Distance(parent.transform.position, this.transform.position);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        this.transform.rotation = rotation;
        this.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y - distance);
	}
}
