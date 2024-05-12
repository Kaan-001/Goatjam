using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public ParticleSystem explosion;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(gameObject.GetComponent<Patrol>().alien.gameObject);
            ParticleSystem a = Instantiate(explosion,this.transform.position,Quaternion.identity);
            a.Play();
        }
    }
}
