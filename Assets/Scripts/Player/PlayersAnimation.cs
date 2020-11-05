using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersAnimation : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    private AudioSource audioSors;

    [SerializeField] AudioClip step;
    [SerializeField] AudioClip chargAttack;
    [SerializeField] AudioClip Attack;
    [SerializeField] AudioClip castBall;
    [SerializeField] AudioClip hurt;

    [SerializeField] float chargeForce = 5f;

    [SerializeField] GameObject deathWind;

    void Start()
    {
        audioSors = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void AnimChargeAttack()
    {
        PlayerMovents.charControl = false;
        rb.velocity = Vector2.zero;
        //transform.position = Vector3.MoveTowards(transform.position, transform.right, chargeForce);
        rb.AddForce(transform.right * chargeForce, ForceMode2D.Impulse);
    }

    public void StopCharge()
    {
        rb.velocity = Vector2.zero;
        PlayerMovents.charControl = true;
    }

    public void Steps()
    {
        audioSors.PlayOneShot(step);
    }

    public void ChargAttack()
    {
        audioSors.PlayOneShot(chargAttack);
    }

    public void AttackKick()
    {
        audioSors.PlayOneShot(Attack);
    }

    public void Cast()
    {
        audioSors.PlayOneShot(castBall);
    }

    public void Hurt()
    {
        audioSors.PlayOneShot(hurt);
    }

    public void Death()
    {
        rb.simulated = false;
        PlayerMovents.charControl = false;
        deathWind.SetActive(true);
    }
}
