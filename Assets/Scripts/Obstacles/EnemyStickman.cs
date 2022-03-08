using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStickman : MonoBehaviour
{
    Animator animator;
    GameObject playerStickman;
    Vector3 hordeCenterPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStickman = GameObject.Find("StickmanCenterReference");
        hordeCenterPosition = transform.parent.position;
    }

    void Update()
    {
        if (hordeCenterPosition.z - playerStickman.transform.position.z < 3.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerStickman.transform.position, 2f * Time.deltaTime);
            
            while (playerStickman.transform.childCount > 0)
            {
                playerStickman.transform.position = Vector3.zero;
            }

        }
    }
}
