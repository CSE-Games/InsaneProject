using System;
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

    public Transform attackPos;
    public float attackRange;
    //public LayerMask attackable;
    public int damage;
    private float canAttack = 0f;
    public float attackDelay;

    public int health;

    //wall jump variable
    public LayerMask ground;
    public float canWallSlide;
    public float wallSlideSpeed;
    //private float canWallJump = 0f;

    float rayDistance = 0.5f;
    bool facingRight = true;
    bool hitWall;
    bool isWallSliding = false;
    float currentYPosition;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        Physics.IgnoreLayerCollision(8, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject canvas = GameObject.Find("Canvas");
            canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(0).gameObject);
            canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(2).gameObject);
            canvas.transform.GetChild(2).gameObject.GetComponent<Fading>().Fade();
        }

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            IsGrounded = true;
            currentYPosition = transform.position.y;
        }
        else
        {
            IsGrounded = false;
        }
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            facingRight = true;
            spriteRenderer.flipX = false;
            anime.SetBool("isRunning", true);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            facingRight = false;
            spriteRenderer.flipX = true;
            anime.SetBool("isRunning", true);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            anime.SetBool("isRunning", false);
        }

        //jumping part
        if ((Input.GetKey("space") && IsGrounded && Time.time > canJump) || (Input.GetKey("space") && isWallSliding))
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

        //attacking part
        if (Input.GetKey(KeyCode.Return) && Time.time > canAttack && IsGrounded)
        {
            anime.SetBool("attacking", true);
            canAttack = Time.time + attackDelay;

            Collider2D[] attackables = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
            for (int i = 0; i < attackables.Length; i++)
            {
                if(attackables[i].CompareTag("Enemy"))
                {
                    EnemyPatrol enemy = attackables[i].GetComponent<EnemyPatrol>();
                    if (enemy != null) { enemy.takeDamage(damage); }
                }
                
                if (attackables[i].CompareTag("Breakables"))
                {
                    attackables[i].GetComponent<breakable>().health -= 1;
                }
            }
        }
        else
        {
            anime.SetBool("attacking", false);
        }



        if(facingRight)
        {
            hitWall = Physics2D.Raycast(transform.position, new Vector2(rayDistance, 0), rayDistance, ground);
        }
        else
        {
            hitWall = Physics2D.Raycast(transform.position, new Vector2(-rayDistance, 0), rayDistance, ground);
        }


        if (hitWall && !IsGrounded && Math.Abs(transform.position.y - currentYPosition) >= canWallSlide)
        {
            isWallSliding = true;
            //canJump = Time.time + jumpDelay;
        } else
        {
            isWallSliding = false;
        }

        if(isWallSliding)
        {
            rb2d.velocity = new Vector2(0, -wallSlideSpeed);
            //Vector2 forceToAdd = new Vector2(wallHopForce * wallHopDirection.x * 1, wallHopDirection.y * wallHopForce);
            //rb2d.AddForce(forceToAdd, ForceMode2D.Impulse);

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void takeDamage(int damage)
    {
        healthUI health_ui = GameObject.Find("Health").GetComponent<healthUI>();
        health_ui.loseLife(health - 1);
        health -= damage;
        
    }
}

