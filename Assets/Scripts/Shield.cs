using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {




    /// <summary>
    /// This script is no longer in use.  See Circle Rotation for movement, or Shot for collision handling;
    /// </summary>
    // Use this for initialization
    void Start() {

    }
    
    private float rotationSpeed = 0;
    //allows player input of max rotation speed
    public float maxRotationSpeed;

    // Update is called once per frame
    void Update() {
        //incrementRotation();
    }

    private void incrementRotation()
    {
        //allows shield to rotate via input
        float change = Input.GetAxis("shield");
        transform.Rotate(Vector3.forward, -change * rotationSpeed);

        if (System.Math.Abs(rotationSpeed) < maxRotationSpeed)
        {
            rotationSpeed -= Input.GetAxis("shield");
            //if (Input.GetKey("v"))
            //{
            //    rotationSpeed += 1;
            //}
            //if (Input.GetKey("n"))
            //{
            //    rotationSpeed -= 1;
            //}
        }
    }

    //destroys bullet when it collides with shield
    private void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shot")
        {
            Destroy(other.gameObject);
        }
    }

}

