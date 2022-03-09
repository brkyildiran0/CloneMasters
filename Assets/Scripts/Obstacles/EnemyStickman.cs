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
        if (playerStickman.transform.childCount != 0)
        {
            if (hordeCenterPosition.z - playerStickman.transform.position.z < 3.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerStickman.transform.position, 2f * Time.deltaTime);
                animator.Play("Punch");
            }

            if (transform.position.z - playerStickman.transform.position.z < 0.4f)
            {
                Object.Destroy(gameObject);
                Object.Destroy(playerStickman.transform.GetChild(0).gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Stickman")
        {
            Object.Destroy(collision.gameObject);
            Object.Destroy(gameObject);
        }
    }
}
