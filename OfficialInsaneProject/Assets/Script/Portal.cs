using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int portalNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (portalNumber == 0)
            {
                collision.transform.position = new Vector2(-23.81f, -27.32f);
            }

            if (portalNumber == 1)
            {
                collision.transform.position = new Vector2(-16.06f, -21.96f);
            }

            if (portalNumber == 2)
            {
                collision.transform.position = new Vector2(-11.03f, -56.36f);
            }

            if (portalNumber == 3)
            {
                collision.transform.position = new Vector2(2.11f, -60.03f);
            }

            if (portalNumber == 4)
            {
                collision.transform.position = new Vector2(-41.89f, -82.53f);
            }
        }
    }
}
 