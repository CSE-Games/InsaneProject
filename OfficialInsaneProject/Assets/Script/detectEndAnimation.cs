using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectEndAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<EnterGame>().changeScene("Opening Scene (Forest Scene)");
        }
    }
}
