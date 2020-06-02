using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public int ammo;
    public GameObject UI;

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

        if (Input.GetMouseButtonDown(1))
        {
            if (timeBtwShots <= 0 && ammo>0)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                ammo--;
                UI.GetComponent<Ammo_UI>().updateAmmo(ammo);
                sound.playSound("rangedAttack");
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void refillAmmo()
    {
        ammo+=5;
        UI.GetComponent<Ammo_UI>().updateAmmo(ammo);
    }
}
