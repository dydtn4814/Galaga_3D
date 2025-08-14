using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera Target이 설정되지 않았습니다.");
            return;
        }

        // 카메라의 위치를 플레이어의 위치에 오프셋을 더한 값으로 즉시 설정합니다.
        transform.position = target.position + target.rotation * offset;

        // 카메라의 회전을 플레이어의 회전과 같게 만듭니다.
        transform.rotation = target.rotation;
    }
}