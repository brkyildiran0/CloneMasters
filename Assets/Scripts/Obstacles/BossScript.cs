using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public static int HP = 10;
    public GameObject player;
    Animator animator;

    void Start()
    {
        HP = 10;
        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }

    void Update()
    {
        if (HP == 0)
        {
            for (int i = 0; i < player.transform.childCount; i++)
            {
                player.transform.GetChild(i).GetComponent<StickmanController>().enabled = true;
                player.transform.GetChild(i).transform.GetComponent<Animator>().Play("Running");
            }
            player.GetComponent<CenterReferenceController>().enabled = true;
        }

        if (gameObject != null && transform.position.z - player.transform.position.z < 3.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
            animator.Play("Punch");

            for (int i = 0; i < player.transform.childCount; i++)
            {
                player.transform.GetChild(i).GetComponent<StickmanController>().enabled = false;
                player.transform.GetChild(i).transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player.transform.GetChild(i).transform.GetComponent<Animator>().Play("Punch");
            }
            player.GetComponent<CenterReferenceController>().enabled = false;
            player.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

            StartCoroutine(MyCounter());
        }
    }

    IEnumerator MyCounter()
    {
        yield return new WaitForSeconds(1f); //wait 1 second per interval
        
        if (HP > 0 && player.transform.childCount > 0)
        {

            Object.Destroy(player.transform.GetChild(0).gameObject);
            HP--;
        }

        if (HP == 0 && gameObject != null)
        {
            Object.Destroy(gameObject);
        }
        
    }
}
