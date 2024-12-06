using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public float skySpeed;
    public float timeDayLight = 1f;
    public Light light;
    public Gradient gradient;
    public float rotationSpeed;
    // Update is called once per frame

    void Start()
    {
        rotationSpeed = 360f / (timeDayLight * 60);   
    }
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skySpeed);
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        if (light != null && gradient != null) 
        {
            float time = Mathf.PingPong(Time.time / (timeDayLight * 30f), 1f);
            light.color = gradient.Evaluate(time);
        }
    }
}
