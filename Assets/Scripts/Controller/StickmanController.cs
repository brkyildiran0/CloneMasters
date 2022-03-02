using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    public GameObject centerReference;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = centerReference.GetComponent<Rigidbody>().velocity;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = centerReference.GetComponent<Rigidbody>().velocity;
        transform.position = Vector3.MoveTowards(transform.position, centerReference.transform.position, 0.2f * Time.deltaTime);
    }
}

