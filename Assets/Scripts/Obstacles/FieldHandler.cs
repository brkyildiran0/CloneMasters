using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FieldHandler : MonoBehaviour
{
    public GameObject stickmanCenter;
    public GameObject stickman;
    public bool triggeredOnce;
    public int totalChildAmount;
    

    void Start()
    {
        triggeredOnce = false;
        totalChildAmount = 0;
    }

    void Update()
    {
        totalChildAmount = stickmanCenter.transform.childCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CenterReferenceStickman" && !triggeredOnce)
        {
            char opCode = GetComponent<TextMeshPro>().text[0];
            string refStr = GetComponent<TextMeshPro>().text.Substring(1, GetComponent<TextMeshPro>().text.Length - 1);
            int amount = int.Parse(refStr);

            switch (opCode)
            {
                case '+':
                    for (int i = 0; i < amount; i++)
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
                    break;

                case '-':
                    if (totalChildAmount > amount)
                    {
                        for (int i = amount - 1; i >= 0; i--)
                        {
                            Object.Destroy(other.transform.GetChild(i).gameObject);
                        }
                    }
                    else if (totalChildAmount < amount)
                    {
                        for (int i = totalChildAmount - 1; i >= 0; i--)
                        {
                            Object.Destroy(other.transform.GetChild(i).gameObject);
                        }
                    }
                    break;

                case 'x':
                    amount = totalChildAmount * amount - totalChildAmount;

                    for (int i = 0; i < amount; i++)
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
                    break;
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