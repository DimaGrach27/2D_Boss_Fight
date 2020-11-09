using UnityEngine;
using Player_and_Enemy_Control;

public class EnemyHealth : AbsHealthSys
{
    private ParticleSystem partSys;

    //private EnemyHealth(float amount)
    //{
    //    MaxHealth = amount;
    //}

    public EnemyHealth()
    {
        MaxHealth = 500f;
    }
    public static float CurrentHealth { get; set; }

    void Start()
    {
        partSys = GetComponent<ParticleSystem>();
        //CurrentHealth = gameObject.AddComponent<EnemyHealth>().MaxHealth;
        CurrentHealth = new EnemyHealth().MaxHealth;
    }

    public override void Damaget(float amount)
    {
        CurrentHealth -= amount;
        partSys.Play();
    }
}

