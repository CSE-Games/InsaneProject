using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // Update is called once per frame
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
