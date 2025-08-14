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

    // 회전 속도 (회전이 부드럽게 되도록)
    public float rotationSpeed = 5f;

    // Update에서 입력 값을 저장하고, FixedUpdate에서 움직임과 회전 적용
    private Vector3 movementInput;

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
        
        // 이동 입력 값을 저장합니다.
        movementInput = new Vector3(horizontalInput, upDownInput, verticalInput);

        // 2. 총알 발사 로직 (Update에 유지 가능)
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void FixedUpdate()
    {
        // 3. 움직임 적용
        Vector3 moveDirection = transform.right * movementInput.x + transform.up * movementInput.y + transform.forward * movementInput.z;
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime, Space.World);

        // 4. 회전 적용
        Quaternion targetRotation = Quaternion.identity;
        if (movementInput.y != 0)
        {
            float targetXRotation = -movementInput.y * 15f;
            targetRotation = Quaternion.Euler(targetXRotation, 0, 0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }
}