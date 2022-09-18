using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class TypeWriter : MonoBehaviour
{




    
   


    public float delay = 0.1f;
    public string fullText;
    float loadScene = 2f;
    public TMP_Text currentText;



    private void Start()
    {

        
        StartCoroutine(ShowText());


    }


    void Update()
    {

    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            
            

            currentText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
            

        }
        yield return new WaitForSeconds(loadScene);
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
