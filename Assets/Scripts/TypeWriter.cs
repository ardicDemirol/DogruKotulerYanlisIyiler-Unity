using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//[RequireComponent(typeof(AudioSource))]

public class TypeWriter : MonoBehaviour
{




    public AudioClip typeSound;
    AudioSource audSrc;

    //public float delay;
    //bool writing = true;

    //[Multiline]
    //public string yazi;

    //Text thisText;

    //private bool GetWriting()
    //{
    //    return writing;
    //}

    //void Start()
    //{
    //    
    //    thisText = GetComponent<Text>();

    //    StartCoroutine(TypeWrite());
    //}


    //IEnumerator TypeWrite()
    //{
    //    foreach(char i in yazi)
    //    {
    //        thisText.text += i.ToString();

    //        audSrc.pitch = Random.Range(0.8f, 1.2f);
    //        audSrc.PlayOneShot(typeSound);

    //        if(i.ToString() == ".")
    //        {
    //            yield return new WaitForSeconds(1);
    //        }
    //        else
    //        {
    //            yield return new WaitForSeconds(delay);
    //        }

    //    }
    //}


    public float delay = 0.1f;
    public string fullText;
    float loadScene = 2f;
    public TMP_Text currentText;



    private void Start()
    {

        audSrc = GetComponent<AudioSource>();
        StartCoroutine(ShowText());


    }


    void Update()
    {

    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            
            audSrc.PlayOneShot(typeSound);

            currentText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
            

        }
        yield return new WaitForSeconds(loadScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
