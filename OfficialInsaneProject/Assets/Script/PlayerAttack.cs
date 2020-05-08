using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask attackable;
    public int damage;


    //public Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(timeBtwAttack<=0)
        {
            //then can attack
            if(Input.GetKey(KeyCode.Return))
            {
                //anime.SetBool("attack", true);
                Collider2D[] attackables = Physics2D.OverlapCircleAll(attackPos.position, attackRange, attackable);
                for(int i = 0; i< attackables.Length;i++)
                {
                    EnemyPatrol enemy = attackables[i].GetComponent<EnemyPatrol>();
                    if (enemy != null) { enemy.takeDamage(damage); }
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            //anime.SetBool("attack", false);
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    
}
