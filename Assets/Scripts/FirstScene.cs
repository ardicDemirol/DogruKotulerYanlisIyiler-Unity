using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
    int currentScene = 5;
    int nextScene = 0;

    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {

            SceneManager.LoadScene(0);
        }
    }
}
