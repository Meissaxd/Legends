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
    private bool isDead = false;

    public int xpReward = 50;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public bool IsDead()
    {
        return isDead;
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
        if (other.CompareTag("PlayerWeapon") && !isDead)
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            isDead = true;
            anim.SetTrigger("Dead");
            Die(); 
        }
    }

    void Die()
    {
      
        PlayerLevel playerLevel = FindObjectOfType<PlayerLevel>();
        if (playerLevel != null)
        {
            playerLevel.AddXP(xpReward);
        }

        // Destroy enemy after delay to let animation play
        Destroy(gameObject, 2f); 
    }
}