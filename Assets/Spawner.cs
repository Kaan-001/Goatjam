using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Düşman prefabı
    public Transform[] spawnPoints; // Spawn noktalarının transform bilgileri
    public float spawnInterval = 2f; // Spawn aralığı (saniye)

    void Start()
    {
        // Belirli aralıklarla SpawnEnemies fonksiyonunu çağır
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    void SpawnEnemies()
    {
        // Rastgele bir spawn noktası seç
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Seçilen spawn noktasında düşman objesini oluştur
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
