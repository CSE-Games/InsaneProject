using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform playerDetection;
    public float distance;
    public float rollSpeed;

    private bool encounter;
    void Start()
    {
        encounter = false;
    }
    void Update()
    {
        RaycastHit2D obstacleInfo = Physics2D.Raycast(playerDetection.position, -transform.right, distance);
        Debug.DrawRay(playerDetection.position, -transform.right, Color.green);

        if(obstacleInfo.collider == true && obstacleInfo.collider.gameObject.tag.Equals("Player"))
        {
            encounter = true;
        }
        else if(obstacleInfo.collider == true && !obstacleInfo.collider.gameObject.tag.Equals("Player"))
        {
            transform.Translate(Vector2.zero);
            encounter = false;
        }

        if (encounter)
            transform.Translate(Vector2.left * rollSpeed * Time.deltaTime);
        
    }
}
