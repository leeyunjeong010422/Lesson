using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//추가과제
//심화 과제 1. 몬스터 기능 추가
//몬스터가 필드에 존재할 때, 탱크 방향으로 이동해야 한다.
//탱크가 몬스터가 연속해서 2초간 닿아있다면 플레이어가 피격된 것으로 판정한다
//2초가 지나기 전 떨어진 경우, 다시 닿았을 때는 처음부터 2초를 카운팅한다
//탱크가 5회 피격된 경우, 콘솔에 게임이 종료되었다는 텍스트와 함께 탱크 오브젝트를 소멸시킨다
//Tip : 씬 내부에 존재하는 오브젝트를 동적으로 탐색하고 싶은 경우 링크를 참고해볼 수 있습니다
//현 조건 상에서는 동적으로 몬스터를 생성하지 않아도 되므로 Find를 사용하지 않아도 처리할 수 있습니다.

//심화 과제 2. 탱크 기능 추가
//기본 과제 1 결과물을 기준으로 아래 기능을 추가하세요
//숫자키 3번으로 캐논 모드로 돌입한다
//캐논 모드 돌입시 FPS 시점으로 변경되며, 탱크의 이동이 불가능해진다.
//캐논 모드에서는 마우스의 움직임에 따라 화면이 회전해야 한다.
//단, 포신의 상하 각도 제한은 적용해야 한다.
//화면 정 가운데에 몬스터가 존재하는 경우에만 마우스 좌클릭으로 캐논을 발사할 수 있다 (공격력 3)
//캐논에는 중력이 적용되지 않는다
//캐논 탄환이 적에게 적중한 경우, 구체 4 범위 내의 다른 몬스터에 스플래시 데미지를 부여한다. (공격력 2)
public class Monster : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    private void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    private void Update()
    {
        // 타겟한테 이동
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RayMover rayMover = collision.gameObject.GetComponent<RayMover>();
            Destroy(gameObject);
        }
    }
}
