using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isAlive;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isAlive = true;

        Destroy(gameObject, 6f);
    }


    private void FixedUpdate()
    {
        if (isAlive)
        {
            rb.velocity = transform.right * 10f;
        }   
        else
            rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthSys player = collision.GetComponent<PlayerHealthSys>();

        if(player != null)
        {
            player.Damaget(25f);
            PlayerHealthSys.isDamaged = true;
        }
        if(collision.gameObject.tag == "Player")
        {
            isAlive = false;
            anim.SetTrigger("Bom");
            Destroy(gameObject, 0.2f);
        }
    }
}
