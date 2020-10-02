using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 1.2f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f;         // Cinemachine Noise Profile Parameter
    private float ShakeElapsedTime = 0f;

    private CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin VirtualCameraNoise;

    // Start is called before the first frame update
    void Start()
    {
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (VirtualCamera != null)
            VirtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShakeElapsedTime > 0)
        {
            // Set Cinemachine Camera Noise parameters
            VirtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
            VirtualCameraNoise.m_FrequencyGain = ShakeFrequency;

            // Update Shake Timer
            ShakeElapsedTime -= Time.deltaTime;
        }
        else
        {
            // If Camera Shake effect is over, reset variables
            VirtualCameraNoise.m_AmplitudeGain = 0f;
            ShakeElapsedTime = 0f;
        }
    }

    public void StartCameraShake()
    {
        ShakeElapsedTime = ShakeDuration;
    }
}
