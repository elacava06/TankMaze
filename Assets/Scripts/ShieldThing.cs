using UnityEngine;
using System.Collections;

public class ShieldThing : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    private int rotationSpeed = 0;

    // Update is called once per frame
    void Update() {
        incrementRotation();
    }

    private void incrementRotation()
    {
        float change = Input.GetAxis("shield");
        transform.Rotate(Vector3.forward, -change * rotationSpeed);
        while (System.Math.Abs(rotationSpeed) < 10)
        {
            if (Input.GetKey("v"))
            {
                rotationSpeed += 1;
            }
            if (Input.GetKey("n"))
            {
                rotationSpeed -= 1;
            }
        }
    }

}