using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FieldAdd : MonoBehaviour
{
    public GameObject stickmanCenter;
    public GameObject stickman;
    public bool triggeredOnce;

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
        if (!triggeredOnce)
        {
            //Instantiate(stickman, other.transform.position + new Vector3(other.GetComponent<Collider>().bounds.size.x, 0, 0), Quaternion.identity);

            //CIRCLE CONSTRAINTS
            float radius;
            if (other.transform.position.x > 0)
            {
                radius = 4.0f - other.transform.position.x;
            }
            else
            {
                radius = other.transform.position.x + 4.0f;
            }

            //SPAWN
            int amountToSpawn = int.Parse(GetComponent<TextMeshPro>().text);
            for (int i = 0; i < amountToSpawn; i++)
            {
                float angle = i * Mathf.PI * 2f / amountToSpawn;
                Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius + other.GetComponent<Collider>().transform.position.x,
                                            other.GetComponent<Collider>().transform.position.y,
                                            Mathf.Sin(angle) * radius + other.GetComponent<Collider>().transform.position.z);
                GameObject go = Instantiate(stickman, newPos, Quaternion.identity);
                go.transform.SetParent(stickmanCenter.transform);
            }

            //RECENTER AROUND THE CENTER OF THE CIRCLE, UNTIL A COLLUSION OCCURS


        }
        triggeredOnce = true;
    }
}
