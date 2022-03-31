using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Animator anim;
    Rigidbody2D fallingPlat;
    public float timeDelay = 2;
    private bool isOff=false;
    // Start is called before the first frame update
    void Start()
    {
        fallingPlat = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("isOff", isOff);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            isOff = true;
            StartCoroutine(FaliingPlatform());
        }

    }
    IEnumerator FaliingPlatform()
    {
        yield return new WaitForSeconds(timeDelay);
        fallingPlat.bodyType = RigidbodyType2D.Dynamic;
        anim.SetBool("isOff", isOff);
        yield return 0;
    }
}
