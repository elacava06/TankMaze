using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Represents the health bar UI
 */
public class HealthBar : MonoBehaviour {

    private Quaternion rotation;
    private float distance;
    private GameObject parent;
    private Slider healthBar;

	// Use this for initialization
	void Start () {
        rotation = this.transform.rotation;
        parent = this.transform.parent.gameObject;
        distance = Vector3.Distance(parent.transform.position, this.transform.position);
        healthBar = this.GetComponentInChildren<Slider>();
        healthBar.maxValue = parent.GetComponentInChildren<TankBody>().getMaxHealth();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        this.transform.rotation = rotation;
        this.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y - distance);
	}

    /*
     * Decreases the fill on the health bar slider by amount
     */
    public void loseHealth(int amount)
    {
        healthBar.value -= amount;
    }

    /*
     * Restores the health bar slider back to the maximum value
     */
    public void fullHealth()
    {
        healthBar.value = healthBar.maxValue;
    }
}
