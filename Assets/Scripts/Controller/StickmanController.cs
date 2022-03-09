using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    private GameObject centerReference;

    void Start()
    {
        centerReference = GameObject.Find("StickmanCenterReference");
        GetComponent<Rigidbody>().velocity = centerReference.GetComponent<Rigidbody>().velocity;

    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = centerReference.GetComponent<Rigidbody>().velocity;
        transform.position = Vector3.MoveTowards(transform.position, centerReference.transform.position, 0.3f * Time.deltaTime);
    }
}

