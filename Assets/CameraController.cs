using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 카메라가 따라갈 대상(플레이어)
    public Transform target;
    // 카메라와 대상 사이의 거리(오프셋)
    public Vector3 offset;

    // LateUpdate()는 모든 Update()가 끝난 후 호출됩니다.
    // 플레이어의 이동이 끝난 후 카메라가 따라가야 자연스럽습니다.
    void LateUpdate()
    {
        // 카메라의 위치를 대상의 위치에 오프셋을 더한 값으로 설정합니다.
        transform.position = target.position + offset;
    }
}
