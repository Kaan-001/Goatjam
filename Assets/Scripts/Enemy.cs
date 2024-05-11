using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // Player'ın konumunu almak için kullanacağımız Transform bileşeni
    public GameObject bulletPrefab; // Ateş mermisinin prefabı
    public float attackRange = 100f; // Düşmanın oyuncuyu ne kadar uzaklıktan algılayacağı
    public float fireRate = 1f; // Ateş hızı (saniye cinsinden)
    public float bulletSpeed = 10f; // Ateş mermisinin hızı
    public Transform firepoint;
    private float nextFireTime = 0f; // Sonraki ateş zamanı
    
    
    void Update()
    {
        // Oyuncuyla düşman arasındaki mesafeyi hesapla
        float distanceToPlayer2 = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer2 <= attackRange)
        {
            Vector2 lookDir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if(angle>-180 && angle<-90)
         {
            this.transform.localScale=new Vector2(1f,-1f);
           
         }
         else if(angle>90 && angle<180)
         {
              this.transform.localScale=new Vector2(1f,-1f);
             
         }
         else{   this.transform.localScale=new Vector2(1f,1f); }
    
        }   
        

        // Eğer oyuncu varsa ve düşmanın ateş hızı kadar zaman geçtiyse
        if (player != null && Time.time >= nextFireTime)
        {
            // Oyuncuyla düşman arasındaki mesafeyi hesapla
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Eğer oyuncu düşmanın ateş menzilindeyse
            if (distanceToPlayer <= attackRange)
            {
                Shoot();
                // Bir sonraki ateş zamanını hesapla
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        // Kurşunun yaratma
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Kurşunun ileri yöne doğru hızlandırılması
        rb.velocity = firepoint.right * bulletSpeed;
    }
}
