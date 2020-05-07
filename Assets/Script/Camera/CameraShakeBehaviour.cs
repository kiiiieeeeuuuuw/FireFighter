using UnityEngine;

public class CameraShakeBehaviour : MonoBehaviour
{    
    private float shakeDuration = 0f;

    private float shakeMagnitude = 0.1f;

    private float dampeningSpeed = 2.0f;

    private Vector3 initialCameraPosition;

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition = initialCameraPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= dampeningSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialCameraPosition;
        }
    }

    private void OnEnable()
    {
        initialCameraPosition = transform.localPosition;
    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
