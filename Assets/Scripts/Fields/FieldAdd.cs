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

                switch (randGenerator)
                {
                    case 0:
                        spawnPosition(-0.3f, 0f);
                        break;
                    case 1:
                        spawnPosition(0f, -0.3f);
                        break;
                    case 2:
                        spawnPosition(0.3f, 0f);
                        break;
                    case 3:
                        spawnPosition(0f, 0.3f);
                        break;
                }
            }
            triggeredOnce = true;
        }
    }

    private void spawnPosition(float xPos, float zPos)
    {
        GameObject prefabStickman = Instantiate(stickman,
                    stickmanCenter.transform.position + new Vector3(xPos, 0f, zPos),
                    Quaternion.identity);
        prefabStickman.transform.SetParent(stickmanCenter.transform);
    }
}