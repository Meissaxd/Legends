using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 80;
    [SerializeField] private Collider weapon;
    private int currentHealth;
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
    public void EnableWeapon()
    {
        weapon.enabled = true;
    }

    public void DisableWeapon()
    {
        weapon.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            TakeDamage(10);
            print("enemy: " + currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth >0)
        {
            print(currentHealth);
            anim.SetTrigger("Hit");
        }
        else
        {
            anim.SetTrigger("Dead");
        }
        
    }
    
}
