using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUIController : MonoBehaviour
{
    public GameObject Screen1;
    public GameObject ControlUI;
    void Update()
    {
        if (Screen1.active == true)
            ControlUI.active = false;
        else ControlUI.active = true;
    }
}
