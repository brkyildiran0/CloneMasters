using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStickmanHUD : MonoBehaviour
{
    public GameObject go;
    private TextMesh HUDText;
    public bool flag;

    void Start()
    {
        HUDText = GetComponent<TextMesh>();
        flag = false;
    }

    void Update()
    {
        transform.position = go.transform.position + new Vector3(0, 1.2f, 0);
        
        if (!flag)
        {
            HUDText.text = go.transform.childCount.ToString();

            if (HUDText.text.Equals("0"))
            {
                Object.Destroy(GetComponent<TextMesh>());
                flag = true;
            }
        }
    }
}
