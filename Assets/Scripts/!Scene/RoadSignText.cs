using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadSignText : MonoBehaviour
{
    [SerializeField] Canvas text;

    private float timeSee { get; set; }
    private bool isActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.gameObject.SetActive(true);
            isActive = true;
            timeSee = 3f;
            
        }
    }

    private void Update()
    {
        if(isActive == true)
        {
            timeSee -= Time.deltaTime;
            if(timeSee < 0)
            {
                text.gameObject.SetActive(false);
                isActive = false;
            } 
        }
    }
}
