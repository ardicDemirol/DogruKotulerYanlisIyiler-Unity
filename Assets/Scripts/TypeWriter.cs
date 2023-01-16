using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class TypeWriter : MonoBehaviour
{
    public float delay;
    int nextSceneIndex;
    [SerializeField] GameObject panel;


    [Multiline]
    public string startText;

    TextMeshProUGUI thisText;

    private void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        thisText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeWrite());
        
        Time.timeScale = 1;
    }

    private void Update()
    {
        StartCoroutine(ShowAllText());
    }

    IEnumerator TypeWrite()
    {
        foreach (char i in startText)
        {
            thisText.text += i.ToString();
            if (i.ToString() == ".")
            {
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
        panel.SetActive(true);
    }

    IEnumerator ShowAllText()
    {
        yield return new WaitForSecondsRealtime(0.4f);

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            thisText.text = startText;
            StopAllCoroutines();
            panel.SetActive(true);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
