using System.Collections;
using UnityEngine;

//추가과제
//심화 과제 3. 수류탄 구현하기
//기본 과제 2 결과물 환경에서 수류탄을 추가 구현하세요
//수류탄은 Capsule을 사용해 구현한다.
//플레이어는 숫자키 1을 누르면 일반 총기, 2를 누르면 수류탄 투척 모드로 변경된다
//모드가 변경되어도 화면에 총기는 그대로 나타낸다
//수류탄 투척 모드인 경우 마우스 좌클릭 시간에 비례한 힘으로 수류탄을 투척한다.
//이 때, 최대 힘의 크기는 자유롭게 설정하되, 인스펙터에서 조절할 수 있어야 한다.
//수류탄이 바닥에 닿은 후 2초 경과시 구형 범위에 폭발을 일으키며, 폭발 범위 내에 몬스터가 있는 경우 피격판정으로 처리한다. (공격력 3)
//폭발 이펙트는 구현하지 않는다.
//폭발을 일으킨 경우, 수류탄 오브젝트는 사라진다
public class FPS_Controller : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] public int attack;

    [SerializeField] Target target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;
    [SerializeField] int maxAmmo = 30;

    private int currentAmmo;
    private bool isFiring;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        Move();
        Look();

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime);
    }
    private void Look()
    {
        float x = Input.GetAxis("Mouse X"); //마우스 좌우 움직임량
        float y = Input.GetAxis("Mouse Y"); //마우스 위아래 움직임량

        //좌우
        transform.Rotate(Vector3.up, rotateSpeed * x * Time.deltaTime);

        //위아래 (카메라만 - 플레이어가 넘어질 수 있음)
        camTransform.Rotate(Vector3.right, rotateSpeed * -y * Time.deltaTime);
    }

    private void Fire()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit))
        {
            GameObject instance = hit.collider.gameObject;
            Target target = instance.GetComponent<Target>();

            if (target != null)
            {
                target.TakeHit(attack);
            }
        }
    }
}
