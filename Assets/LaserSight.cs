using UnityEngine;

public class LaserSight : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform firePoint;
    public float maxLaserDistance = 1000f;
    
    // 레이캐스트가 무시할 레이어를 설정하는 변수
    public LayerMask ignoreLayers;

    void Awake()
    {
        // LineRenderer 컴포넌트를 가져옵니다.
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // 발사 지점에서 전방으로 레이캐스트를 발사합니다.
        // '~ignoreLayers'를 사용하여 설정된 레이어를 제외한 모든 것과 충돌합니다.
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxLaserDistance, ~ignoreLayers))
        {
            // 레이캐스트가 물체에 부딪혔을 때, 레이저의 시작점과 끝점을 설정합니다.
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // 레이캐스트가 아무것도 부딪히지 않았을 때,
            // 레이저의 시작점과 최대 거리 끝점을 설정합니다.
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * maxLaserDistance);
        }
    }
}