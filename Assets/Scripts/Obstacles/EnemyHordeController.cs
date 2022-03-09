using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHordeController : MonoBehaviour
{
    GameObject playerStickman;
    bool flag;

    void Start()
    {
        playerStickman = GameObject.Find("StickmanCenterReference");
        flag = false;
    }

    void Update()
    {
        if (flag && transform.childCount == 0)
        {
            flag = false;
            gameObject.SetActive(false);

            for (int i = 0; i < playerStickman.transform.childCount; i++)
            {
                playerStickman.transform.GetChild(i).GetComponent<StickmanController>().enabled = true;
                playerStickman.transform.GetChild(i).transform.GetComponent<Animator>().Play("Running");
            }
            playerStickman.GetComponent<CenterReferenceController>().enabled = true;
        }

        else if (!flag && transform.position.z - playerStickman.transform.position.z < 3.0f)
        {
            for (int i = 0; i < playerStickman.transform.childCount; i++)
            {
                playerStickman.transform.GetChild(i).GetComponent<StickmanController>().enabled = false;
                playerStickman.transform.GetChild(i).transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                playerStickman.transform.GetChild(i).transform.GetComponent<Animator>().Play("Punch");
            }
            playerStickman.GetComponent<CenterReferenceController>().enabled = false;
            playerStickman.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

            flag = true;
        }
    }
}
