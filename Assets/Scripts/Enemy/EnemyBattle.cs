using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player_and_Enemy_Control;

public class EnemyBattle : AbsBattletSys
{
    [SerializeField] Transform player;

    [SerializeField] Transform castPoint;
    [SerializeField] GameObject fireball;

    [SerializeField] Transform attackPoint;

    private Rigidbody2D rb;
    private Animator anim;

    public LayerMask playerMask;
    public float attackRange;

    private float timeBetweenAttack; // переменная времени между атаками
    private bool isAttack;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetBool("Diz", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (!isAttack && !anim.GetBool("Diz")) //проверяем не атакует ли сейчас персонаж, что бы не ьыор 100000 вызовов атаки в 1 кадр
        {
            if (((transform.position.x > player.position.x) && (transform.position.x < player.position.x + 20f)) ||
            ((transform.position.x < player.position.x) && (transform.position.x > player.position.x - 20f)))
            {
                AttackControlFirstAttack();
                AttackControlCastFireBall();
                AttackControlChargeAttack();

                timeBetweenAttack = Random.Range(1f, 2f);
            }
            else
            {
                AttackControlCastFireBall();
                timeBetweenAttack = Random.Range(0.3f, 0.6f);
            }

            isAttack = true;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;

            if (timeBetweenAttack < 0)
            {
                isAttack = false;
            }
        
        }
            
    }

    private void AttackControlFirstAttack()
    {
        if (((transform.position.x > player.position.x) && (transform.position.x < player.position.x + 1.5f)) ||
            ((transform.position.x < player.position.x) && (transform.position.x > player.position.x - 1.5f)))
        {
                anim.SetTrigger("Attack1");

                Damage = 10f;
        }
    }

    private void AttackControlCastFireBall()
    {
        if (((transform.position.x > player.position.x + 8f) && (transform.position.x < player.position.x + 29f)) ||
            ((transform.position.x < player.position.x - 8f) && (transform.position.x > player.position.x - 29f)))
        {
                anim.SetTrigger("Cast");
        }
    }

    private void AttackControlChargeAttack()
    {
        if (((transform.position.x > player.position.x + 2f) && (transform.position.x < player.position.x + 10f)) ||
            ((transform.position.x < player.position.x - 2f) && (transform.position.x > player.position.x - 10f)))
        {
                anim.SetTrigger("Attack2");

                Damage = 30f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawCube(attackPoint.position, new Vector3(2f, 0.5f));
    }

    public void OnAttack()
    {
        //Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerMask);

        Collider2D player = Physics2D.OverlapBox(attackPoint.position, new Vector2(2f, 0.5f), 0f, playerMask);

        if (player != null)
        {
            player.GetComponent<PlayerHealthSys>().Damaget(Damage);
            PlayerHealthSys.isDamaged = true;
        }

    }

    public void AnimCast()
    {
        Instantiate(fireball, castPoint.position, castPoint.rotation);
    }
}