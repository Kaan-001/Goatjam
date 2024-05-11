using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Patrol noktalarını tutacak dizi
    public float moveSpeed = 5f; // Düşmanın hızı
    public float patrolRange = 10f; // Patrol menzili
    public float minWaitTime = 2f; // Minimum bekleme süresi
    public float maxWaitTime = 4f; // Maksimum bekleme süresi

    private Transform currentPatrolPoint; // Şu anki patrol noktası
    private int lastPatrolIndex = -1; // Son seçilen patrol noktasının index'i
    private bool isWaiting = false; // Bekleme durumunu kontrol etmek için flag
    
    void Start()
    {
        // İlk başta bir patrol noktası seç
        SelectPatrolPoint();
    }

    void Update()
    {
        // Eğer beklemiyorsak ve şu anki patrol noktası varsa
        if (!isWaiting && currentPatrolPoint != null)
        {
            // Hedef patrol noktasına doğru ilerle
            MoveToPatrolPoint(currentPatrolPoint.position);

            // Eğer düşman hedef patrol noktasına ulaştıysa
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
            {
                // Bekleme süresini başlat
                float waitTime = Random.Range(minWaitTime, maxWaitTime);
                Invoke("SelectPatrolPoint", waitTime);
                isWaiting = true; // Bekleme durumunu true olarak ayarla
            }
        }
    }

    void SelectPatrolPoint()
    {
        // Rastgele bir patrol noktası seç
        int randomIndex = Random.Range(0, patrolPoints.Length);

        // Seçilen noktanın son seçilenle aynı olmadığından emin ol
        while (randomIndex == lastPatrolIndex)
        {
            randomIndex = Random.Range(0, patrolPoints.Length);
        }

        // Seçilen noktayı şu anki patrol noktası olarak ayarla
        currentPatrolPoint = patrolPoints[randomIndex];

        // Son seçilen index'i güncelle
        lastPatrolIndex = randomIndex;

        isWaiting = false; // Bekleme durumunu false olarak ayarla
    }

    void MoveToPatrolPoint(Vector3 targetPosition)
    {
        // Hedefe doğru yönel
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}