using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyrController : MonoBehaviour
{
    
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool IsGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private float runSpeed = 5f;

    [SerializeField]
    private float jumpHeight = 5f;

    private Animator anime;
    private float canJump = 0f;
    public float jumpDelay;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            IsGrounded = true;
        }
        else
        {

            IsGrounded = false;
        }
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;
            anime.SetBool("isRunning", true);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
            anime.SetBool("isRunning", true);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            anime.SetBool("isRunning", false);
        }
        if (Input.GetKey("space") && IsGrounded && Time.time > canJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            canJump = Time.time + jumpDelay;
            anime.SetTrigger("takeOff");
        }

        if(rb2d.velocity.y<=0 && !IsGrounded)
        {
            anime.SetBool("goingDown", true);
        }
        else
        {
            anime.SetBool("goingDown", false);
            anime.SetTrigger("landing");
        }

        /*if(IsGrounded)
        {
            anime.SetBool("goingDown", false);
        }*/
        
    }   
}
