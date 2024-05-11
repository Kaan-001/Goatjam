using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCont : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 20f;
    public float deflectionRate;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Kurşunun yaratma
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Kurşunun ileri yöne doğru hızlandırılması
        rb.velocity = firePoint.right * bulletSpeed;

        // Rasgele hata payı ekleme
        float errorAngle = Random.Range(-deflectionRate, deflectionRate);
        rb.velocity = Quaternion.Euler(0, 0, errorAngle) * rb.velocity;
    }
}
