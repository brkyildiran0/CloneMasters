using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHUD : MonoBehaviour
{
    public GameObject go;
    private TextMesh HUDText;
    GameObject gameOverScreen;

    void Start()
    {
        HUDText = GetComponent<TextMesh>();
        HUDText.text = "10";
        gameOverScreen = GameObject.Find("WorldCanvas");
    }

    void Update()
    {
        if (go != null)
        {
            transform.position = go.transform.position + new Vector3(0, 2.5f, 0);

            HUDText.text = BossScript.HP.ToString();

            if (HUDText.text.Equals("1"))
            {
                Object.Destroy(GetComponent<TextMesh>());
                Time.timeScale = 0;
                gameOverScreen.transform.GetChild(gameOverScreen.transform.childCount - 1).gameObject.SetActive(true);
            }
        }
    }
}
