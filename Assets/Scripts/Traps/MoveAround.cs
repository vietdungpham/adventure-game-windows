using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public Animator anim;
    public float movementDistanceOy, movementDistanceOx;
    public float speed;
    public bool movingDown=false, movingLeft=false, hit = false;
    public float downEdge, upEdge;
    public float leftEdge, rightEdge;
    private void Awake()
    {
        downEdge = transform.position.y - movementDistanceOy;
        upEdge = transform.position.y + movementDistanceOy;
        leftEdge = transform.position.x - movementDistanceOx;
        rightEdge = transform.position.x + movementDistanceOx;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        /*anim.SetBool("hit", hit);
        anim.SetBool("movingLeft", movingDown);*/
        if (!movingLeft && !movingDown)
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y);
                Debug.Log(transform.position);
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
                Debug.Log(transform.position);
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
                Debug.Log(transform.position);
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
                Debug.Log(transform.position);
            }
            else
            {
                movingLeft = false;
            }
        }
        //Up Down
           /* if (transform.position.y >= downEdge && transform.position.x == leftEdge)
            {
            movingDown = false;
            }
        if (transform.position.y == upEdge&&transform.position.x==leftEdge)
        {
            movingLeft = false;
            //transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed);
        }
        if (transform.position.y == upEdge&&transform.position.x==rightEdge)
        {
            movingDown = true;
        }
        if (transform.position.y == downEdge&&transform.position.x==rightEdge)
        {
            movingLeft = true;
            //transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed);
        }
        if (!movingDown && !movingLeft)
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y);
            }
        }
        else if (movingDown && !movingLeft)
        {
            if (transform.position.y > downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed);
            }
        }
        else if (movingDown && movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y);
            }
        }
        else if (!movingDown && movingLeft)
        {
            if (transform.position.y < upEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed);
            }
        }*/

    }
}
