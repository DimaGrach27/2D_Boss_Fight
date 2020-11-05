using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
    [SerializeField] GameObject hidenCamp;
    [SerializeField] Transform maskCamp;
    [SerializeField] GameObject hideElements;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            maskCamp.position = new Vector3(maskCamp.position.x, maskCamp.position.y, 10);
            hideElements.SetActive(false);
            hidenCamp.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            maskCamp.position = new Vector3(maskCamp.position.x, maskCamp.position.y, 0);
            hideElements.SetActive(true);
            hidenCamp.SetActive(false);
        }
    }
}
