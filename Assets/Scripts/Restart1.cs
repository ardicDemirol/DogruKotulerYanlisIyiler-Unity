using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart1 : MonoBehaviour
{
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("RestartScene",2);
    }

     void RestartScene()
    {
        
        SceneManager.LoadScene("Scene1");
        
    }


}
