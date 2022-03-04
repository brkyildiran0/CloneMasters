using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    public GameObject go;
    private TextMesh HUDText;

    void Start()
    {
        HUDText = GetComponent<TextMesh>();
        go = GameObject.Find("StickmanCenterReference");
    }

    void Update()
    {
        transform.position = go.transform.position + new Vector3(0, 1.2f, 0);
        HUDText.text = go.transform.childCount.ToString();
    }
}
