using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            boss.GetComponent<Animator>().SetTrigger("Awake");
            boss.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            boss.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            wall.SetActive(true);

            Destroy(gameObject);
        }
    }
}
