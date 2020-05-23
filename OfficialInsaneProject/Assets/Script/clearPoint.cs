using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class clearPoint : MonoBehaviour
{
    public GameObject boss;
    bool end = false;
    void Update()
    {
        if(end == false)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (boss == null)
            {
                canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(0).gameObject);
                canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(1).gameObject);
                canvas.transform.GetChild(1).gameObject.GetComponent<Fading>().Fade();

                end = true;
            }
        }
        
    }

    
}
