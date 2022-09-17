using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeController : MonoBehaviour
{

    public static ShakeController Instance { get; private set; }
    private CinemachineVirtualCamera _cam;
    private float shakeTimer = 1f;




    private void Awake()
    {
        Instance = this;
        _cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity,float time)
    {

        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();



        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;


    }

    private void Update()
    {
        

        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();



                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }

        
    }

}
