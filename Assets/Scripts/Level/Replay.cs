using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{

    public void replayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
