using UnityEngine;
using System.Collections;

public class destroyBlocks : MonoBehaviour {

    public float rotationSpeed;
    public float drillRange;
    public float withdrawSpeed;
    private bool drilling=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        incrementRotation();
        if(Input.GetAxis("drill") !=0 && !drilling)
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
        Vector3 originalPosition = transform.position;
        transform.Translate(transform.rotation * Vector3.up * drillRange);
        int i = 0;
        while((transform.position - originalPosition).magnitude < .01)
        {
            GetComponent<Rigidbody2D>().velocity = (originalPosition - transform.position).normalized*withdrawSpeed;
            i++;
            if (i > 20)
            {
                Debug.Log("infinite loop");
                break;
            }
            yield return null;
        }
        transform.position = originalPosition;
        drilling = false;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (drilling)
        {
            if (coll.gameObject.tag == "wall")
            {
                Destroy(coll.gameObject);
            }
        }
    }
}
