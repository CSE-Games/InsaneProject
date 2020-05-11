using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fading : MonoBehaviour
{
    public bool isFaded = false;
    public GameObject gb;
    public float Duration = 0.4f;
    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        //var button = GetComponent<Button>();

        //Toggle the end value depending on the faded state ( from 1 to 0)
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, isFaded ? 1 : 0));

        //Toggle the faded state
        isFaded = !isFaded;
        if(isFaded)
        {
            gb.SetActive(false);
        }
        else
        {
            gb.SetActive(true);
        }
    }
    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)//Runto complition beforex
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null; //Because we don't need a return value.
        }
    }
}
