using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool CanChoose = true;
    float timer = 0f;
    public float interval = 3f;
    public Animator anim;

    public Transform player; // Player'ın konumunu almak için kullanacağımız Transform bileşeni
    public GameObject bulletPrefab; // Ateş mermisinin prefabı
    public float fireRate = 1f; // Ateş hızı (saniye cinsinden)
    public float bulletSpeed = 10f; // Ateş mermisinin hızı
    public Transform firepoint;

    public Transform[] firePoints; // Ateş edilecek noktaların transform bilgileri

    private float nextFireTime = 0f; // Sonraki ateş zamanı

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void RandomSkill()
    {

        // Zaman sayacını arttır
        timer++;

        // Belirlenen aralığa ulaşıldığında rasgele bir fonksiyonu çağır
        if (timer >= interval && (CanChoose == true))
        {
            int randomState = Random.Range(0, 2);
            Debug.Log(randomState);
            if (randomState == 0)
            {
                anim.SetBool("Fonk1", true);
                CanChoose = false;
            }
            else if (randomState == 1)
            {
                anim.SetBool("Fonk2", true);
                CanChoose = false;
            }
            timer = 0f;
        }
    }

    public void Function1()
    {
        if (Time.time >= nextFireTime)
        {
            // Player'ın konumuna doğru ateş et
            Debug.Log("skill1");
            Vector3 shootDirection = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            firepoint.rotation = Quaternion.Euler(0f, 0f, angle);
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firepoint.right * bulletSpeed;

            // Bir sonraki ateş zamanını hesapla
            nextFireTime = Time.time + 1f / fireRate;
            anim.SetBool("Fonk1", false);
        }
    }
    public  float[] angles;
    public bool once;
    public void Function2()
    {
           Debug.Log("skill2");
            if (Time.time >= nextFireTime)
        {
              for(int i=0;i<8;i++)
           {
             firepoint.rotation = Quaternion.Euler(0f, 0f, angles[i]);
             GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firepoint.right * bulletSpeed;
           }
          nextFireTime = Time.time + 1f / fireRate;
          Debug.Log("Fonk2 çalıştı");
            anim.SetBool("Fonk2", false);
        }

         
        
    }
}
