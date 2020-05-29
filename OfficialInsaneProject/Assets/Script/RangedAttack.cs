using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    //public int rounds;

    private float timeBtwShots;
    public float startTimeBtwShots;

    SoundEffects sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.Find("Sound Effects").GetComponent<SoundEffects>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("k"))
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                sound.playSound("rangedAttack");
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
