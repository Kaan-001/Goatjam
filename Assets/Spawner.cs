using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Düşman prefabı
    public Transform[] spawnPoints; // Spawn noktalarının transform bilgileri
     // Spawn aralığı (saniye)
    public static int SpawnCount=0;

    void Start()
    {
        // Belirli aralıklarla SpawnEnemies fonksiyonunu çağır
        StartCoroutine(SpawnEnemies());
        
    }

     IEnumerator SpawnEnemies()
    {
        // Rastgele bir spawn noktası seç
        while(true)
        {
            yield return new WaitForSeconds(2f);
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Seçilen spawn noktasında düşman objesini oluştur
        if(SpawnCount<6)
        {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        SpawnCount+=1;
        }
        }
        
       
    }
}
