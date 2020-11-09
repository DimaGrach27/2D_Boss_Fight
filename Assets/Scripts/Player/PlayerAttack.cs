using System.Collections;
using UnityEngine;
using Player_and_Enemy_Control;

public class PlayerAttack : AbsBattletSys
{

    private float timeBtwAttack = 0;
    private bool isAttack;
    public static float reloadAttack;

    public Transform castPoint;
    public GameObject fireball;

    public Transform attackPosition;
    public LayerMask enemyMask;
    public float attackRange;

    private Animator anim;
    private Rigidbody2D rb;

    private bool isCharge = false;
    public static float reloadTimeCharg;

    private bool isCastBall = false;
    public static float reloadTimeCast;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        if (!isAttack && !PlayerHealthSys.isDeath) //проверяем не атакует ли сейчас персонаж, что бы не ьыор 100000 вызовов атаки в 1 кадр
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Attack1();
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                StartCoroutine(AttackCharge());
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(CastBall());
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;

            if (timeBtwAttack < 0)
            {
                isAttack = false;
            }
        }

    }

    
    private void Attack1()
    {
        anim.SetTrigger("Attack1");
        Damage = 15f;

        timeBtwAttack = 0.5f;
        reloadAttack = timeBtwAttack;
        isAttack = true;
    }

    IEnumerator CastBall()
    {
        if (!isCastBall)
        {
            isCastBall = true;

            reloadTimeCast = 3f;
            Debug.Log(reloadTimeCast);
            anim.SetTrigger("Cast");

            yield return new WaitForSeconds(3f);
            isCastBall = false;
        }


    }

    public void AnimCastBall()
    {
        Instantiate(fireball, castPoint.position, castPoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
       // Gizmos.DrawWireSphere(attackPosition.position, attackRange);
        Gizmos.DrawCube(attackPosition.position, new Vector3(2f, 0.5f));
    }

    public void OnAttack()
    {
        Collider2D enemy = Physics2D.OverlapBox(attackPosition.position, new Vector2(2f, 0.5f), 0f, enemyMask);

        if (enemy != null)
            enemy.GetComponent<EnemyHealth>().Damaget(Damage);

        isAttack = true;
    }

    IEnumerator AttackCharge()
    {
        if (!isCharge)
        {
            isCharge = true;

            reloadTimeCharg = 3f;


            anim.SetTrigger("Attack2");
            Damage = 30f;
            //rb.AddForce(transform.right * 10f, ForceMode2D.Impulse);

            yield return new WaitForSeconds(3f);
            isCharge = false;
        }
    }

}

