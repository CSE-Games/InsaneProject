using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    public int health;
    public GameObject destroyEffect;
    public GameObject bonusText;
    public Transform textPos;
    void Update()
    {
        if(health<=0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            GetComponent<Bonus>().bonus();
            Instantiate(bonusText, textPos.position, Quaternion.identity);
            GameObject.Find("Sound Effects").GetComponent<SoundEffects>().playSound("destruction");
            Destroy(gameObject);
        }
    }
}
