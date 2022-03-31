using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public Animator anim;
    public float movementDistance;
    public float speed;
    public bool movingDown, hit = false;
    public float downEdge, upEdge;
    private void Awake()
    {
        downEdge = transform.position.y - movementDistance;
        upEdge = transform.position.y + movementDistance;
        anim = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*void Update()
    {
        anim.SetBool("hit", hit);
        anim.SetBool("movingLeft", movingLeft);
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y);
            }
            else
            {
                movingLeft = true;
            }
        }
    }*/
    private void FixedUpdate()
    {

        anim.SetBool("hit", hit);
        anim.SetBool("movingLeft", movingDown);
        if (movingDown)
        {
            if (transform.position.y > downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed);
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
                movingDown = true;
            }
        }
    }

}
