using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHUD : MonoBehaviour
{
    public GameObject go;
    private TextMesh HUDText;

    void Start()
    {
        HUDText = GetComponent<TextMesh>();
        HUDText.text = "10";
    }

    void Update()
    {
        if (go != null)
        {
            transform.position = go.transform.position + new Vector3(0, 2.5f, 0);

            HUDText.text = BossScript.HP.ToString();

            if (HUDText.text.Equals("0"))
            {
                Object.Destroy(GetComponent<TextMesh>());
            }
        }
    }
}
