using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 70f, maxspeed = 2f, jumpPow = 100f;
    public bool grounded = true, faceright = true, canDoubleJump=false,isJump=false;
    public Rigidbody2D r2;
    public Animator anim;
    //public Point item;
    
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        SoundManager.instance.PlaySound(SoundManager.instance.background,0.8f,true);
        r2.position = new Vector2(-28, -4);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);//gan Grounded= grounded
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));//gan speed=toc do cua nguoi choi
        anim.SetBool("doubleJump", canDoubleJump);
        anim.SetBool("isJump", isJump);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                canDoubleJump = true;
                grounded = false;
                //isJump = true;
                r2.AddForce(Vector2.up * jumpPow);
                SoundManager.instance.PlaySound(SoundManager.instance.jump, 2f);
                //anim.SetBool("isJump", isJump);
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                r2.velocity = new Vector2(r2.velocity.x, 0);
                r2.AddForce(Vector2.up * jumpPow * 0.7f);
                SoundManager.instance.PlaySound(SoundManager.instance.jump, 2f);


            }
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxspeed)
        {
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        }
        if (r2.velocity.x < -maxspeed)
        {
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        }
        if (h > 0 && !(faceright))
        {
            Flip();
        }
        else if (h < 0 && faceright)
        {
            Flip();
        }
        if (grounded)
        {
            r2.velocity = new Vector2(0.0f, r2.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            Death();
            SoundManager.instance.PlaySound(SoundManager.instance.gameOver, 1f);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Items"))
        {
            SoundManager.instance.PlaySound(SoundManager.instance.items, 0.2f);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Trap"))
        {
            Death();
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void Death()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(1);
    }

}