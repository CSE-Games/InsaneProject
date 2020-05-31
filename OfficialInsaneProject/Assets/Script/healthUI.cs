using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseLife(int ui_life)
    {
        gameObject.transform.GetChild(ui_life).GetComponent<Image>().color = Color.grey;
    }

    public void gainLife(int ui_life)
    {
        gameObject.transform.GetChild(ui_life).GetComponent<Image>().color = Color.white;
    }
}
