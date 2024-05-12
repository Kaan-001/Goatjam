using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Spawner.SpawnCount-=1;
            ParticleSystem a = Instantiate(explosion,this.transform.position,Quaternion.identity);
            a.Play();
             PlayerMovement.ScoreC+=1;
        }
       
      
        if( PlayerMovement.ScoreC>=30)
        {
            //sahne değişimi
            SceneManager.LoadScene(3);

        }
    }
}
