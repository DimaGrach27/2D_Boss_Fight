using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNight : MonoBehaviour
{
    Light2D light2D;

    private void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        DateTime someDate = DateTime.Now;

        //light2D.intensity = 2f;


        //if (someDate.Hour > 17 || someDate.Hour < 4)
        //    light2D.intensity = 0.2f;
        //else
        //    light2D.intensity = 0.8f;

    }
}
