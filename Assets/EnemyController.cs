// EnemyController.cs
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}