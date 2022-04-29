using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoveAround : MonoBehaviour
{
    public MoveAroundType moveType;

    public float movementDistanceOy, movementDistanceOx;

    public float speed;

    private bool movingDown, movingLeft;

    private float downEdge, upEdge, leftEdge, rightEdge;

    private void Awake()
    {
        if (moveType == MoveAroundType.FirstLeft)
            movingLeft = movingDown = true;
        downEdge = transform.position.y - movementDistanceOy;
        upEdge = transform.position.y + movementDistanceOy;
        leftEdge = transform.position.x - movementDistanceOx;
        rightEdge = transform.position.x + movementDistanceOx;
    }

    private void FixedUpdate()
    {
        if (!movingLeft && !movingDown)
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y);
            }
            else
            {
                movingDown = true;
            }
        }
        else if (!movingLeft && movingDown)
        {
            if (transform.position.y > downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed);
            }
            else
            {
                movingLeft = true;
            }
        }
        else if (movingLeft && movingDown)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y);
            }
            else
            {
                movingDown = false;
            }
        }
        else
        {
            if (transform.position.y < upEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed);
            }
            else
            {
                movingLeft = false;
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

public enum MoveAroundType { FirstLeft = 0, FirstRight = 1 }