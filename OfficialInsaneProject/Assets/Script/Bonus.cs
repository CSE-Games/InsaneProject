using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject Myr;
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bonus()
    {
        if(type == 0)
        {
            Myr.gameObject.GetComponent<MyrController>().gainHealth();
        }

        if (type == 1)
        {
            Myr.gameObject.GetComponent<RangedAttack>().refillAmmo();
        }
    }
}
