using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public Animator anim;
    public float movementDistance;
    public float speed;
    public bool movingLeft, hit = false;
    public float leftEdge, rightEdge;
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
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
    }

}
