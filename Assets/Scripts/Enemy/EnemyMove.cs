using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player_and_Enemy_Control;

public class EnemyMove : AbsMoventSys
{
    [SerializeField] Transform player;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isRdyToRun;

    private float timeBtwRun;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Speed = 7f;

        anim.SetBool("Diz", false);
    }

    private void FixedUpdate()
    {
        if (!isRdyToRun)
        {
            timeBtwRun -= Time.deltaTime;

            if (timeBtwRun <= 0)
                isRdyToRun = true;
        }


        if (isRdyToRun)
            Move();
        else
            anim.SetBool("isRuning", false);
    }

    private void Move()
    {
        if (!anim.GetBool("Diz") && EnemyHealth.CurrentHealth > 0)
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRuning", false);

            if (transform.position.x > player.position.x + 0.5f && transform.position.x < player.position.x + 8f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                anim.SetBool("isRuning", true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.fixedDeltaTime); // с помошью Vector2.MoveTowards мы можем перемещать обьект с к другой

            }
            else if (transform.position.x < player.position.x - 0.5f && transform.position.x > player.position.x - 8f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                anim.SetBool("isRuning", true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.fixedDeltaTime);

            }
        }
        
    }

    public void RedyToBtwRun()
    {
        isRdyToRun = false;
        timeBtwRun = Random.Range(0.5f, 0.9f);
    }
    
}
