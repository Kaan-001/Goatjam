using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCont : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 20f;
    public static int neryebakiyor=0;
    public float deflectionRate;
  //-90-180 e kdr 90 dan 180 e kdr y si - olmalı
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
       
        Vector2 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         if(angle>-180 && angle<-90)
         {
            this.transform.localScale=new Vector2(1f,-1f);
            neryebakiyor=1;
         }
         else if(angle>90&&angle<180)
         {
              this.transform.localScale=new Vector2(1f,-1f);
               neryebakiyor=1;
         }
         else{   this.transform.localScale=new Vector2(1f,1f);  neryebakiyor=0;}
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
