using UnityEngine;

public class BulletController : MonoBehaviour
{
// 총알 이동 속도
public float moveSpeed = 10.0f;
void Update()
{
    // 총알을 앞으로 이동시킵니다.
    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    // 총알이 너무 멀리 날아가서 화면을 벗어나면 삭제
    Destroy(gameObject, 3.0f);
}
}