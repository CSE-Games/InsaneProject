using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform playerDetection;
    public Transform playerDetection2;
    public Transform playerDetection3;
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
        RaycastHit2D obstacleInfo2 = Physics2D.Raycast(playerDetection2.position, -transform.right, distance);
        RaycastHit2D obstacleInfo3 = Physics2D.Raycast(playerDetection3.position, -transform.right, distance);
        Debug.DrawRay(playerDetection.position, -transform.right, Color.green);

        if(obstacleInfo.collider == true && obstacleInfo.collider.gameObject.tag.Equals("Player") ||
            obstacleInfo2.collider == true && obstacleInfo2.collider.gameObject.tag.Equals("Player") ||
            obstacleInfo3.collider == true && obstacleInfo3.collider.gameObject.tag.Equals("Player"))
        {
            encounter = true;
        }
        else if(obstacleInfo.collider == true && !obstacleInfo.collider.gameObject.tag.Equals("Player") ||
            obstacleInfo2.collider == true && !obstacleInfo2.collider.gameObject.tag.Equals("Player") ||
            obstacleInfo3.collider == true && !obstacleInfo3.collider.gameObject.tag.Equals("Player"))
        {
            transform.Translate(Vector2.zero);
            encounter = false;
        }

        if (encounter)
            transform.Translate(Vector2.left * rollSpeed * Time.deltaTime);
        
    }
}
