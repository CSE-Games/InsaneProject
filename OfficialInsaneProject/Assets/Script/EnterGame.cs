using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    public string scene;
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            changeScene(scene);
        }
    }
}
