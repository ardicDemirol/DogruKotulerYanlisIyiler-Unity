using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
   

    

    
    

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            Debug.Log("next level point");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
