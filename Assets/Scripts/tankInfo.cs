using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Represents a tank
 */
public class TankInfo : MonoBehaviour {

    public int teamNumber;
    public Slider healthBar;

	// Use this for initialization
	void Start () {
        if (teamNumber == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (teamNumber == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
     * Lowers the value of the health slider by amount
     */
    public void loseHealth(int amount)
    {
        this.healthBar.value -= amount;
    }

}
