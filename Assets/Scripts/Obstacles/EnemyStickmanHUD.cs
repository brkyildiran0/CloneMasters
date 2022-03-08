using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStickmanHUD : MonoBehaviour
{
    public GameObject go;
    private TextMesh HUDText;

    void Start()
    {
        HUDText = GetComponent<TextMesh>();
        go = GameObject.Find("Horde 1");
    }

    void Update()
    {
        transform.position = go.transform.position + new Vector3(0, 1.2f, 0);
        HUDText.text = go.transform.childCount.ToString();
    }
}
