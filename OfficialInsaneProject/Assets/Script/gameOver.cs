using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    public GameObject gb;
    
    public void end()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (gb == null)
        {
            canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(0).gameObject);
            canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(2).gameObject);
            canvas.transform.GetChild(2).gameObject.GetComponent<Fading>().Fade();
        }
       
    }
    
}
