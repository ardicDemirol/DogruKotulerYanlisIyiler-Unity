using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    public static ShakeController Instance { get; private set; }

    private float shakeTimer;
    private CinemachineVirtualCamera cmVirCam;


    private void Awake()
    {
        Instance = this;
        cmVirCam = GetComponent<CinemachineVirtualCamera>();
    }


    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cmVirCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cmVirCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = Time.time;
    }
}







    //public bool start = false;
    //[SerializeField] float duration = 1f;
    //[SerializeField] AnimationCurve curve;


    //public void Update()
    //{
    //    if (start)
    //    {
    //        StartCoroutine(Shaking());
    //    }

    //}

    //public IEnumerator Shaking()
    //{
    //    Vector3  startPos = transform.position;
    //    float elapsedTime = 0f;

    //    while(elapsedTime < duration)
    //    {
    //        elapsedTime+=Time.deltaTime;
    //        float strenght = curve.Evaluate(elapsedTime / duration);
    //        transform.position += Random.insideUnitSphere * strenght / 50;
    //        yield return new WaitForSecondsRealtime(1f);
    //    }
    //    start = false;
    //}



