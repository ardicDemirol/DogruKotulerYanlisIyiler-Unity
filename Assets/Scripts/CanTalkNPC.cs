using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTalkNPC : MonoBehaviour
{

    bool isTouching = false;

    private GameManager gameManager;

    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isTouching = true;
            
        }
    }

}
