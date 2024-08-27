using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float maxDistance; //최대 거리
    [SerializeField] LayerMask layerMask; //여기서 체크한 오브젝트는 부딪히고 언체크한 오브젝트는 안부딪힘

    private void Update()
    {
        //어디서 나오는지 표현가능 (game창에는 표시 X)
        //Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * 100, Color.red); //색깔 뒤에 몇 초 동안 그릴건지 초도 지정해줄 수 있음

        //Raycast: 첫번째에 부딪힌 거 찾기 (bool형) --> 부딪히면 true, 아니면 false
        //RaycastAll: 뒤에 있는 것도 다 부딪힘 (배열형)

        //RaycastHit hit; //어떻게 부딪혔는지 (부딪힌 정보)

        //Physics.Raycast(쏘는 위치, 쏘는 방향, 부딪힌 정보(out), 최대거리, 레이어마스크(충돌확인 그룹 - 타켓 그룹))
        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hit, maxDistance, layerMask))
        {
            //레이저에 부딪힌 게 있을 때
            //Debug.Log("광선에 부딪힌 물체가 있습니다.");
            Debug.Log($"{hit.collider.gameObject.name}이랑 부딪혔고, 거리는 {hit.distance}m 떨어져있습니다.");
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hit.distance, Color.red);
            //여기 아직 못 쓴 코드 있음....
        }
        else
        {
            //부딪힌 게 없을 때
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red);
        }
    }
}
