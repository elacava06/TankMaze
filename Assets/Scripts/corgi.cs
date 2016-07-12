using UnityEngine;
using System.Collections;

/**
 * Represents a corgi
 */
public class corgi : MonoBehaviour
{
    public float speed;
    public bool eric;
    public bool sam;
    private int xVelocity = 0;
    private int yVelocity = 0;

    public GameObject projectile;

    private Rigidbody2D body;
    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(createOrgy());
    }
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (sam)
        {
            updateMovement2();
        }
        if (eric)
        {
            updateMovement();
        }
        if (i < 3)
        {
            
        }
    }

    /**
     * Moves the corgi depending on which directional key is held down 
     */
    private void updateMovement()
    {
        //increases y velocity (up to 10) while up key is pressed
        if (Input.GetKey("up"))
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 10)
            {
                yVelocity += 1;
            }
        }

        //decreases y velocity (down to -10) while down key is pressed
        if (Input.GetKey("down"))
        {
            if (GetComponent<Rigidbody2D>().velocity.y > -10)
            {
                yVelocity += -1;
            }
        }

        //decreases x velocity (down to -10) while left key is pressed
        if (Input.GetKey("left"))
        {
            if (GetComponent<Rigidbody2D>().velocity.x > -10)
            {
                xVelocity += -1;
            }
        }

        //increases x velocity (up to 10) while right key is pressed
        if (Input.GetKey("right"))
        {
            if (GetComponent<Rigidbody2D>().velocity.x < 10)
            {
                xVelocity += 1;
            }
        }

        //sets new velocity
        GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
    }

    void updateMovement2()
    {
        body.velocity = new Vector3(0,0,0);
        Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        body.velocity = inputs * speed;
    }

    IEnumerator createOrgy()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            shot.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.value, Random.value) * speed;
            yield return new WaitForSeconds(1);
        }
        Destroy(gameObject);
    }
}
