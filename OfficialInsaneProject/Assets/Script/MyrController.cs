using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyrController : MonoBehaviour
{
    
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool IsGrounded;
    bool offGround;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    private float runSpeed = 5f;

    [SerializeField]
    private float jumpHeight = 5f;

    private Animator anime;
    private float canJump = 0f;
    public float jumpDelay;
    public int extraJump;

    public Transform attackPos;
    public float attackRange;
    public LayerMask attackable;
    public int damage;
    private float canAttack = 0f;
    public float attackDelay;

    public int health;

    //wall jump variable
    public LayerMask wall;
    public float canWallSlide;
    public float wallSlideSpeed;
    //private float canWallJump = 0f;
    float rayDistance = 0.5f;
    bool facingRight = true;
    bool hitWall;
    bool isWallSliding = false;
    float currentYPosition;

    //dash variables
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int dashDirection;
    public GameObject dashEffectLeft;
    public GameObject dashEffectRight;

    SoundEffects sound;

    private float dazedTime;
    public float startDazedTime;
    private bool dazed;

    public bool wallJumpActivator;
    public bool dashActivator;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sound = GameObject.Find("Sound Effects").GetComponent<SoundEffects>();

        dashTime = startDashTime;
        dazed = false;

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

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
           (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
           (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platforms")))))
        {
            IsGrounded = true;
            currentYPosition = transform.position.y;
        }
        else
        {
            IsGrounded = false;
            offGround = true;
        }
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            facingRight = true;
            //spriteRenderer.flipX = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            anime.SetBool("isRunning", true);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            facingRight = false;
            //spriteRenderer.flipX = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
            anime.SetBool("isRunning", true);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            anime.SetBool("isRunning", false);
        }

        //jumping part
        if ((Input.GetKeyDown("space") && IsGrounded && Time.time > canJump) || (Input.GetKey("space") && isWallSliding))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            canJump = Time.time + jumpDelay;
            anime.SetTrigger("takeOff");
            sound.playSound("jump");
        }

        if(IsGrounded == true)
        {
            extraJump = 1;
        }
        if (Input.GetKeyDown("space") && extraJump > 0) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            extraJump--;
        }
            
        

        if(rb2d.velocity.y<=0 && !IsGrounded)
        {
            anime.SetBool("goingDown", true);
        }
        else
        {
            anime.SetBool("goingDown", false);
            anime.SetTrigger("landing");
            if(offGround && IsGrounded)
            {
                sound.playSound("land");
                offGround = false;
            }
                
        }

        //attacking part
        if (Input.GetMouseButtonDown(0) && Time.time > canAttack && dashDirection == 0)
        {
            anime.SetBool("attacking", true);
            canAttack = Time.time + attackDelay;

            Collider2D[] attackables = Physics2D.OverlapCircleAll(attackPos.position, attackRange, attackable);
            for (int i = 0; i < attackables.Length; i++)
            {
                sound.playSound("slashHit");
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

            if(attackables.Length<=0)
                sound.playSound("slash");
        }
        else
        {
            anime.SetBool("attacking", false);
        }


        //wall jump part
        if(wallJumpActivator)
        {
            if (facingRight)
            {
                hitWall = Physics2D.Raycast(transform.position, new Vector2(rayDistance, 0), rayDistance, wall);
            }
            else
            {
                hitWall = Physics2D.Raycast(transform.position, new Vector2(-rayDistance, 0), rayDistance, wall);
            }


            if (hitWall && !IsGrounded && Math.Abs(transform.position.y - currentYPosition) >= canWallSlide)
            {
                isWallSliding = true;
                //canJump = Time.time + jumpDelay;
            }
            else
            {
                isWallSliding = false;
            }

            if (isWallSliding)
            {
                rb2d.velocity = new Vector2(0, -wallSlideSpeed);
                //Vector2 forceToAdd = new Vector2(wallHopForce * wallHopDirection.x * 1, wallHopDirection.y * wallHopForce);
                //rb2d.AddForce(forceToAdd, ForceMode2D.Impulse);

            }
        }
        

        //dash part
        if(dashActivator)
        {
            if (dashDirection == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (facingRight)
                        Instantiate(dashEffectRight, transform.position, Quaternion.identity);
                    else
                        Instantiate(dashEffectLeft, transform.position, Quaternion.identity);
                    dashDirection = 1;
                    sound.playSound("dash");
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    dashTime = startDashTime;
                    rb2d.velocity = Vector2.zero;
                    dashDirection = 0;
                    anime.SetBool("dashing", false);
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (facingRight)
                        rb2d.velocity = Vector2.right * dashSpeed;
                    else
                        rb2d.velocity = Vector2.left * dashSpeed;
                    anime.SetBool("dashing", true);

                }
            }
        }
        

        if (dazedTime > 0)
            dazedTime -= Time.deltaTime;
        else
            dazed = false;

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

        spriteRenderer.color = Color.red;
        dazedTime = startDazedTime;
        if(health>0)
        {
            Invoke("resetMaterial", 0.2f);
        }
    }

    public void gainHealth()
    {
        healthUI health_ui = GameObject.Find("Health").GetComponent<healthUI>();
        

        if(health<5)
        {
            health_ui.gainLife(health);
            health += damage;
        }
    }

    void resetMaterial()
    {
        spriteRenderer.color = Color.white;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dazedTime>0 && !dazed)
        {
            if (collision.CompareTag("Enemy"))
            {
                Debug.Log(dazedTime);
                Vector2 difference = transform.position - collision.transform.position;
                rb2d.AddForce(new Vector2(difference.x, 0) * 3000);
            }
            dazed = true;
        }
        
    }


}

