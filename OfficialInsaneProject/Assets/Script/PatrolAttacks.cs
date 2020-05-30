using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAttacks : MonoBehaviour
{
    private float canAttack = 0f;
    public float attackDelay;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time > canAttack)
        {
            MyrController player = collision.gameObject.GetComponent<MyrController>();
            player.takeDamage(damage);
            canAttack = Time.time + attackDelay;
        }

    }
}
