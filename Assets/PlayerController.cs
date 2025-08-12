using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed = 1000.0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    void Update()
    {
        // 1. 키보드 입력 받기
        // 'Horizontal'은 A/D 키 또는 좌/우 화살표 키를 의미합니다.
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
        // 2. 이동 방향 계산
        // x축으로만 움직이므로 Vector3.right를 사용합니다.
        Vector3 movement = Vector3.right * horizontalInput + Vector3.forward * verticalInput + Vector3.up * upDownInput;
        
        // 3. 이동 적용
        // transform.Translate를 사용해 플레이어를 이동시킵니다.
        // Time.deltaTime을 곱하여 프레임 속도에 관계없이 동일한 속도로 움직이게 합니다.
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // bulletPrefab을 firePoint 위치에 회전 없이 생성
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }

    }
}