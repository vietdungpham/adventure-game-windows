using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 70f, maxSpeed = 2f, jumpPow = 100f;

    public Rigidbody2D characterRigid;

    public Animator characterAnimator;

    private bool grounded = true, faceRight = true, canDoubleJump = false, isJump = false;

    public Action GetItemEvent;

    public Action DeathEvent;

    void Update()
    {
        characterAnimator.SetBool("Grounded", grounded);
        characterAnimator.SetFloat("Speed", Mathf.Abs(characterRigid.velocity.x));
        characterAnimator.SetBool("doubleJump", canDoubleJump);
        characterAnimator.SetBool("isJump", isJump);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                canDoubleJump = true;
                grounded = false;
                characterRigid.AddForce(Vector2.up * jumpPow);
                SoundManager.instance.PlaySound(SoundManager.instance.jump, 2f);
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                characterRigid.velocity = new Vector2(characterRigid.velocity.x, 0);
                characterRigid.AddForce(Vector2.up * jumpPow * 0.7f);
                SoundManager.instance.PlaySound(SoundManager.instance.jump, 2f);


            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        characterRigid.AddForce((Vector2.right) * speed * h);
        if (characterRigid.velocity.x > maxSpeed)
        {
            characterRigid.velocity = new Vector2(maxSpeed, characterRigid.velocity.y);
        }
        if (characterRigid.velocity.x < -maxSpeed)
        {
            characterRigid.velocity = new Vector2(-maxSpeed, characterRigid.velocity.y);
        }
        if (h > 0 && !(faceRight))
        {
            Flip();
        }
        else if (h < 0 && faceRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    #region Collider2D-Checker
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            grounded = true;
            isJump = false;
            canDoubleJump = false;
        }

        if (collision.CompareTag("Items"))
        {
            GetItemEvent?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            grounded = false;
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            DeathEvent?.Invoke();
        }
    }
    #endregion

}