using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthSlider; 


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("VURDU");
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth; 
    }

    void Die()
    {
        Debug.Log("ÖLDÜ");
        //GameOverPanel.SetActive = true;
        //Time.timeScale = 0;
    }
}
