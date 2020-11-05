using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player_and_Enemy_Control;

public class PlayerHealthSys : AbsHealthSys
{
    private Animator anim;

    public bool isinvulnerability;
    private float timeToInvulnerability = 1f;

    [SerializeField] float MaxHealth;
    public static float CurrentHealth { get; set; }

    public static bool isDamaged = false;

    private bool isRdyDeath;
    public static bool isDeath;

    void Start()
    {
        anim = GetComponent<Animator>();
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;

        isRdyDeath = false;
        isDeath = false;
    }

    void FixedUpdate()
    {
        if (isinvulnerability)
        {
            timeToInvulnerability -= Time.deltaTime;
            if (timeToInvulnerability < 0)
            {
                isinvulnerability = false;
            }
        }

        if (CurrentHealth <= 0 && !isDeath)
            isRdyDeath = true;
        if (isRdyDeath)
        {
            anim.SetTrigger("Death");
            isDeath = true;
            isRdyDeath = false;
        }
    }

    public override void Damaget(float amount)
    {
        if (!isinvulnerability)
        {
            CurrentHealth -= amount;
            isinvulnerability = true;
            anim.SetTrigger("Hurt");
        }

    }
}
