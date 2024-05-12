using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset; 
    void Start()
    {
        Destroy(this.gameObject,3f);
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
            transform.LookAt(target.position);
        }
    }

    public float damageAmount = 50f;
    public float bossdamageAmount = 5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            BossHealth bosshealth = collision.GetComponent<BossHealth>();
            if (bosshealth != null)
            {
                bosshealth.TakeDamage(bossdamageAmount);
            }
            Destroy(gameObject);
        }

    }

}