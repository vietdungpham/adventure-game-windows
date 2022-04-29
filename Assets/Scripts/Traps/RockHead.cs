using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    public float movementDistance;

    public float speed = 10;

    private bool movingFrom;

    private float fromEdge, toEdge;

    // Start is called before the first frame update
    void Start()
    {
        fromEdge = transform.position.x - movementDistance;
        toEdge = transform.position.x + movementDistance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingFrom)
        {
            if (transform.position.x > fromEdge)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y);
            }
            else
            {
                movingFrom = false;
            }
        }
        else
        {
            if (transform.position.x < toEdge)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y);
            }
            else
            {
                movingFrom = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Ground"))
        {
            //Play animation

        }

        if (other.collider.tag.Equals("Player"))
        {
            //Game fail
        }
    }
}
