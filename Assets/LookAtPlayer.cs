using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Camera Object;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Object.transform);
    }
}
