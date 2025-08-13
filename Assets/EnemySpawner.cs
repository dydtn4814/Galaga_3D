using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2.0f;
    private float nextSpawnTime = 0.0f;
    public Transform playerTransform;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;
            
            float randomX = Random.Range(-15.0f, 15.0f);
            float randomY = Random.Range(5.0f, 10.0f);
            float spawnDistance = 90.0f;
            
            Vector3 spawnPosition = new Vector3(playerTransform.position.x + randomX, playerTransform.position.y + randomY, playerTransform.position.z + spawnDistance);
            
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.playerTransform = playerTransform;
            }
        }
    }
}