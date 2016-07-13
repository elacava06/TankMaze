using UnityEngine;
using System.Collections;

public class destroyBlocks : MonoBehaviour {

    public float rotationSpeed;
    public float drillRange;
    public float drillTime;
    public float drillCooldown;
    private bool drilling=false;
    // Use this for initialization
    Rigidbody2D body;

    void Start () {
        body = GetComponent<Rigidbody2D>();
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
        Vector3 originalPosition = transform.localPosition;
        Debug.Log(originalPosition);
        body.velocity = transform.rotation * Vector3.up* drillRange/drillTime;
        //Debug.Log(velocity);
        yield return new WaitForSeconds(drillTime);
        //transform.Translate(transform.rotation * Vector3.up * drillRange);
        float distance = (originalPosition - transform.localPosition).magnitude;
        body.velocity = (originalPosition - transform.localPosition).normalized * (distance / drillCooldown);
        //Debug.Log(velocity);
        yield return new WaitForSeconds(drillCooldown);
        body.velocity = Vector3.zero;
        transform.localPosition = originalPosition;
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
