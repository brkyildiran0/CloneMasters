using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    public GameObject go;
    private TextMesh HUDText;
    GameObject gameOverScreen;

    void Start()
    {
        HUDText = GetComponent<TextMesh>();
        go = GameObject.Find("StickmanCenterReference");
        gameOverScreen = GameObject.Find("WorldCanvas");
    }

    void Update()
    {
        transform.position = go.transform.position + new Vector3(0, 1.2f, 0);
        HUDText.text = go.transform.childCount.ToString();

        if (HUDText.text.Equals("0"))
        {
            Time.timeScale = 0;
            gameOverScreen.transform.GetChild(gameOverScreen.transform.childCount - 1).gameObject.SetActive(true);
        }
    }
}
