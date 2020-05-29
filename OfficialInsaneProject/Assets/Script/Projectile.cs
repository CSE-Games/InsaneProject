using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask enemy;
    public GameObject effect;

    SoundEffects sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.Find("Sound Effects").GetComponent<SoundEffects>();
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, enemy);
        if(hitInfo.collider!=null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyPatrol>().takeDamage(damage);
                
            }

            if (hitInfo.collider.CompareTag("Breakables"))
            {
                hitInfo.collider.GetComponent<breakable>().health-=1;
                
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            DestroyProjectile();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        sound.playSound("endProjectile");
    }
}
