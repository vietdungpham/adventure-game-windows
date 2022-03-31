using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public MoveLeftRight Obj;
    // Start is called before the first frame update
    void Start()
    {
        Obj = gameObject.GetComponentInParent<MoveLeftRight>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Obj.hit = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        Obj.hit = false;
    }
}
