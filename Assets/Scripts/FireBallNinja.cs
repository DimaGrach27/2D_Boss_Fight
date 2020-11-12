using UnityEngine;

public class FireBallNinja : MonoBehaviour
{
    private AudioSource audioSourse;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isAlive;

    private float damage;

    private void Start()
    {
        audioSourse = GetComponent<AudioSource>();
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
            damage += 0.5f;
        }
        else
            rb.velocity = Vector2.zero;

        transform.localScale += new Vector3(0.03f, 0.03f, 0); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.Damaget(damage);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            isAlive = false;
            anim.SetTrigger("Bom");
        }
    }

    public void PlaySoun() => audioSourse.Play();
    public void Destroy() => Destroy(gameObject);
  
}
