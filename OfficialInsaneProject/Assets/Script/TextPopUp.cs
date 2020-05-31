using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public float dissapearTimer;
    private Color textColor;
    private TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
        textColor = textMesh.color;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.3f) * Time.deltaTime;
        dissapearTimer -= Time.deltaTime;
        if(dissapearTimer<0)
        {
            float dissapearSpeed = 3f;
            textColor.a -= dissapearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if(textColor.a <=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
