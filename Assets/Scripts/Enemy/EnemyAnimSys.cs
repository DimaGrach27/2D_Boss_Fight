using UnityEngine;

public class EnemyAnimSys : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public bool diz200;
    public bool diz100;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        diz100 = false;
        diz200 = false;
    }

    void Update()
    {
        
        if(EnemyHealth.CurrentHealth <= 0)
        {
            anim.SetTrigger("Death");
            
        }

        EnemyDiz();
    }

    public void Death() 
    { 
        Destroy(gameObject); 
        rb.simulated = false; 
    }


    public void StopCharg() => rb.velocity = Vector3.zero;
  

    private void EnemyChargAttack() => rb.AddForce(transform.right* 10f, ForceMode2D.Impulse);
   

    private void EnemyDiz()
    {
        if(EnemyHealth.CurrentHealth <= 200 && !diz200)
        {
            diz200 = true;
            anim.SetBool("Diz", true);
        }
        if(EnemyHealth.CurrentHealth <= 100 && !diz100)
        {
            anim.SetBool("Diz", true);
            diz100 = true;
        }
    }

    private void StopDiz() => anim.SetBool("Diz", false);
    

    
}

