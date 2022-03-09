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
        Time.timeScale = 1;
    }
    
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3((joystick.Horizontal * 9), 0, 5);

        if (transform.position.x < -4.8f && transform.position.x < 0f)
        {
            transform.position = new Vector3(-4.79f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 4.8f && transform.position.x > 0f)
        {
            transform.position = new Vector3(4.79f, transform.position.y, transform.position.z);
        }
    }
}
