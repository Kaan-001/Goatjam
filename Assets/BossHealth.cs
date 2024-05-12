using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 3020f;
    public Slider bosshealthSlider;
    private float currentHealth;
    public ParticleSystem explosion;
    public GameObject furniture;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Spawner.SpawnCount -= 1;
            ParticleSystem a = Instantiate(explosion, this.transform.position, Quaternion.identity);
            a.Play();

            if (furniture != null)
            {
                furniture.SetActive(true); // Möbleyi aktif hale getir
            }
        }
    }

    void UpdateHealthUI()
    {
        bosshealthSlider.value = currentHealth / maxHealth;
    }
}
