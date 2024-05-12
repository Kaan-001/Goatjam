using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player; // Player'ı referans alacak değişken
    public GameObject bulletPrefab; // Ateş mermisinin prefabı
    public float attackRange = 100f; // Düşmanın oyuncuyu ne kadar uzaklıktan algılayacağı
    public float fireRate = 1f; // Ateş hızı (saniye cinsinden)
    public float bulletSpeed = 10f; // Ateş mermisinin hızı
    public Transform firepoint;
    private float nextFireTime = 0f; // Sonraki ateş zamanı

    private void Start()
    {
        // Player'ı etiketine göre bul
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player == null) // Player yoksa işlemi durdur
            return;

        // Oyuncuyla düşman arasındaki mesafeyi hesapla
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Eğer oyuncu düşmanın ateş menzilindeyse ve ateş hızı kadar zaman geçtiyse
        if (distanceToPlayer <= attackRange && Time.time >= nextFireTime)
        {
            // Player'a doğru ateş et
            Shoot();
            // Bir sonraki ateş zamanını hesapla
            nextFireTime = Time.time + 1f / fireRate;
        }

        // Oyuncunun konumunu takip et
        LookAtPlayer();
    }

    void Shoot()
    {
        // Ateş mermisini oluştur ve hedefe doğru gönder
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firepoint.right * bulletSpeed;
    }

    void LookAtPlayer()
    {
        // Player'a doğru bak
        Vector2 lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Eğer player sol taraftaysa yönünü çevir
        if (angle > -180 && angle < -90)
        {
            this.transform.localScale = new Vector2(1f, -1f);
        }
        else if (angle > 90 && angle < 180)
        {
            this.transform.localScale = new Vector2(1f, -1f);
        }
        else
        {
            this.transform.localScale = new Vector2(1f, 1f);
        }
    }
}
