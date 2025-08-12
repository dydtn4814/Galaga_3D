using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이어 이동 속도
    public float moveSpeed = 1000.0f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // 총알 발사 속도 (1초에 몇 발)
    public float fireRate = 0.2f;
    // 다음 총알을 발사할 수 있는 시간
    private float nextFire = 0.0f;

    void Update()
    {
        // 1. 키보드 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float upDownInput = 0.0f;
        if (Input.GetKey(KeyCode.E))
        {
            upDownInput = 1.0f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            upDownInput = -1.0f;
        }
        
        // 2. 이동 방향 계산 및 적용
        Vector3 movement = Vector3.right * horizontalInput + Vector3.forward * verticalInput + Vector3.up * upDownInput;
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        
        // 3. 현재 시간이 다음 발사 시간보다 크면 총알 발사
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}