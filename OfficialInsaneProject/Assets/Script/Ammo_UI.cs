using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo_UI : MonoBehaviour
{
    public GameObject ammoCount;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Ammo: " + ammoCount.GetComponent<RangedAttack>().ammo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateAmmo(int ammo)
    {
        GetComponent<Text>().text = "Ammo: " + ammo;
    }
}
