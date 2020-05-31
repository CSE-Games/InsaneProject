using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    public int health;
    public GameObject destroyEffect;
    void Update()
    {
        if(health<=0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            GameObject.Find("Sound Effects").GetComponent<SoundEffects>().playSound("destruction");
            GetComponent<Bonus>().bonus();
            Destroy(gameObject);
        }
    }
}
