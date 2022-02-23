using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
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
            GetComponent<Rigidbody>().velocity.y,
            2f);
    }
}
