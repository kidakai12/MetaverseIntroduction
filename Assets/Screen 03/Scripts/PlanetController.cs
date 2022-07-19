using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlanetController : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float speedY;

    public float speedZ;

    public float torque;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1f *Time.deltaTime, 0);
    }
}
