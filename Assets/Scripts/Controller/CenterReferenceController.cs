using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterReferenceController : MonoBehaviour
{
    protected Joystick joystick;
    

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(
            joystick.Horizontal * 6f,
            0,
            4f);
    }
}
