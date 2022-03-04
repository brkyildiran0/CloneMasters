using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CenterReferenceController : MonoBehaviour
{
    protected Joystick joystick;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }
    
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3((joystick.Horizontal * 9), 0, 5);
    }
}
