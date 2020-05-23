using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    //private GameObject[] object_array;
    //private ArrayList list;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        /*object_array = FindObjectsOfType<GameObject>();
        list = new ArrayList();
        for (int i = 0; i < object_array.Length; i++)
        {
            if (object_array[i].layer == 8 || object_array[i].layer == 10)
            {
                list.Add(object_array[i]);
            }
        }*/
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(0).gameObject);
            canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(4).gameObject);
            //canvas.transform.GetChild(4).gameObject.GetComponent<Fading>().Fade();

            Time.timeScale = 0;
            
        }
    }

    public void continueGame()
    {
        GameObject.Find("Pause").SetActive(false);
        canvas.GetComponent<Enabling>().disable(canvas.transform.GetChild(0).gameObject);
        Time.timeScale = 1;
    }

    public void options()
    {
        Time.timeScale = 1;
        GameObject.Find("Pause").SetActive(false);
        canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(5).gameObject);
        canvas.transform.GetChild(5).gameObject.GetComponent<Fading>().Fade();
    }

    public void optionsExit()
    {
        canvas.GetComponent<Enabling>().enable(canvas.transform.GetChild(4).gameObject);
        canvas.transform.GetChild(5).gameObject.GetComponent<Fading>().Fade();
        canvas.GetComponent<Enabling>().disable(canvas.transform.GetChild(5).gameObject);
        

    }
}
