using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FieldAdd : MonoBehaviour
{
    public GameObject stickmanCenter;
    public GameObject stickman;
    public bool triggeredOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        triggeredOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "CenterReferenceStickman" && !triggeredOnce)
        {
            int amountToSpawn = int.Parse(GetComponent<TextMeshPro>().text);
            for (int i = 0; i < amountToSpawn; i++)
            {
                int randGenerator = Random.Range(0, 4);
                if (randGenerator == 0)
                {
                    GameObject prefabStickman = Instantiate(stickman,
                    stickmanCenter.transform.position + new Vector3(-0.3f,0f,0f),
                    Quaternion.identity);
                    prefabStickman.transform.SetParent(stickmanCenter.transform);
                }
                else if (randGenerator == 1)
                {
                    GameObject prefabStickman = Instantiate(stickman,
                    stickmanCenter.transform.position + new Vector3(0f, 0f, -0.3f),
                    Quaternion.identity);
                    prefabStickman.transform.SetParent(stickmanCenter.transform);
                }
                else if (randGenerator == 2)
                {
                    GameObject prefabStickman = Instantiate(stickman,
                    stickmanCenter.transform.position + new Vector3(0.3f, 0f, 0f),
                    Quaternion.identity);
                    prefabStickman.transform.SetParent(stickmanCenter.transform);
                }
                else
                {
                    GameObject prefabStickman = Instantiate(stickman,
                    stickmanCenter.transform.position + new Vector3(0f, 0f, 0.3f),
                    Quaternion.identity);
                    prefabStickman.transform.SetParent(stickmanCenter.transform);
                }
            }
            triggeredOnce = true;
        }
    }
}