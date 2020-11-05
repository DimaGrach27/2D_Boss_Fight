using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player_and_Enemy_Control;

public class EnemyHealth : AbsHealthSys
{
    private ParticleSystem partSys;

    [SerializeField] float MaxHealth;

    public static float CurrentHealth { get; set; }
    //{ 
    //    get { return CurrentHealth; }
    //    set 
    //    {
    //        if (value <= 0)
    //            CurrentHealth = value;
    //        else
    //            CurrentHealth = 0f;
    //    } 
    //}


    void Start()
    {
        partSys = GetComponent<ParticleSystem>();
        MaxHealth = 250f;
        CurrentHealth = MaxHealth;
        Debug.Log($"Enemy{MaxHealth}");
        
    }

    // Update is called once per frame
    public override void Damaget(float amount)
    {
        CurrentHealth -= amount;
        Debug.Log($"Enemy HP:{CurrentHealth}");
        partSys.Play();

    }
}

