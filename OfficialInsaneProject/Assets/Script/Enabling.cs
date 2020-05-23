using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enabling : MonoBehaviour
{
    public void enable(GameObject gb)
    {
        gb.SetActive(true);
    }

    public void disable(GameObject gb)
    {
        gb.SetActive(false);
    }
}
