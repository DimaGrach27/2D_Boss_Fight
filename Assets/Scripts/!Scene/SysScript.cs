using System;
using UnityEngine;
using UnityEngine.UI;

public class SysScript : MonoBehaviour
{
    [SerializeField] GameObject nigthDay;
    [SerializeField] Text dataTime;


    void Update()
    {

        DateTime someDate = DateTime.Now;

        someDate.ToLocalTime();
        dataTime.text = someDate.ToShortTimeString();

        if (someDate.Hour > 12)
            nigthDay.SetActive(true);
        else
            nigthDay.SetActive(false);
    }
}
