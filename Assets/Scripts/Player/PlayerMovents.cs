using UnityEngine;
using Player_and_Enemy_Control;

public class PlayerMovents : AbsMoventSys
{
    public static bool playTimeLine;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float rayCast = 1.3f;

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] static public bool charControl = true;

    private float timeToControl = 0.5f;
    private float timeStartLostControl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        playTimeLine = true;

        Speed = 10f;
        JumpForce = 7f;

    }

    private void Update()
    {
        if (!PlayerHealthSys.isDeath && !playTimeLine)
            Jump();

            if (!charControl)
        {
            if (timeStartLostControl > 0)
                timeStartLostControl -= Time.deltaTime;
            else
                charControl = true;
        }
    }

    private void FixedUpdate()
    {
        if(!PlayerHealthSys.isDeath && !playTimeLine)
            Move();

        OnDamagetPlayer();
    }

    private void Move()
    {

        Vector3 moveVelocity = Vector3.zero;
        anim.SetBool("isRuning", false);

        if (charControl && Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;

            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetBool("isRuning", true);

        }
        if (charControl && Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetBool("isRuning", true);

        }
        transform.position += moveVelocity * Speed * Time.deltaTime;
    }

    private bool isGrounded()
    {
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, rayCast, whatIsGround);
        if(ground.collider != null)
        {

            return true;
        }

        return false;
    }
    private void Jump()
    {
        if (charControl && Input.GetButtonDown("Jump") && !anim.GetBool("isJump") && isGrounded() == true)
        {
            anim.SetBool("isJump", true);
            anim.SetTrigger("Jumping");

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, JumpForce);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }


        if(isGrounded() == true)
        {
            anim.SetBool("isJump", false);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        LaserMove laser = collision.GetComponent<LaserMove>();
        if(laser != null)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(laser.push, ForceMode2D.Impulse);
            charControl = false;
            timeStartLostControl = timeToControl;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        LaserMove laser = collision.GetComponent<LaserMove>();
        if (laser != null)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(laser.push, ForceMode2D.Impulse);
            charControl = false;
            timeStartLostControl = timeToControl;
        }
    }

    public void OnDamagetPlayer()
    {
        if (PlayerHealthSys.isDamaged)
        {
            PlayerHealthSys.isDamaged = false;
            rb.AddForce((transform.right + transform.up) * new Vector2(-7f, 2f), ForceMode2D.Impulse);

            Debug.Log((transform.right + transform.up) * new Vector2(-7f, 2f));
        }
    }
}

