using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private float timeBetweenHits = 1f;
    [SerializeField] private Collider[] weapons;
    private int currentHealth;
    private int currentMaxHealth;
    private float lastHitTime = 0;
    private Animator anim;
    

    public static bool isAlive = true;
    
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value < 0)
                currentHealth = 0;
            else
                currentHealth = value;
        }
    }
    public void EnableWeapon()
    {
        foreach (Collider weapon in weapons)
            weapon.enabled = true;
    }

    public void DisableWeapon()
    {
        foreach (Collider weapon in weapons)
            weapon.enabled = false;
        
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
        currentMaxHealth = startingHealth;
        isAlive = true;
        DisableWeapon();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("EnemyWeapon") && Time.time - lastHitTime > timeBetweenHits && isAlive)
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        lastHitTime = Time.time;
        currentHealth -= damage;
        print(currentHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            anim.SetTrigger("isDead");
            isAlive = false;
        }
    }

    public float GetHealthRatio()
    {
        return (float)currentHealth / (float)currentMaxHealth;
    }
    
   
}
