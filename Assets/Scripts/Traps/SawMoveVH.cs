using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoveVH : MonoBehaviour
{
    public MoveType moveType;

    public float movementDistance;

    public float speed = 10;

    private bool movingFrom;

    private float fromEdge, toEdge;

    // Start is called before the first frame update
    void Start()
    {
        if (moveType == MoveType.Verticle)
        {
            fromEdge = transform.position.y - movementDistance;
            toEdge = transform.position.y + movementDistance;
        }
        else
        {
            fromEdge = transform.position.x - movementDistance;
            toEdge = transform.position.x + movementDistance;
        }
    }

    private void FixedUpdate()
    {
        if (moveType == MoveType.Verticle)
        {
            if (movingFrom)
            {
                if (transform.position.y > fromEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed);
                }
                else
                {
                    movingFrom = false;
                }
            }
            else
            {
                if (transform.position.y < toEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed);
                }
                else
                {
                    movingFrom = true;
                }
            }
        }
        else
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Player"))
        {
            //Game fail
        }
    }
}

public enum MoveType { Verticle = 0, Horizontal = 1 }
