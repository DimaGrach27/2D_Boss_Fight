using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amunition : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerSw;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.SetActive(false);
            playerSw.SetActive(true);
        }
    }

}
