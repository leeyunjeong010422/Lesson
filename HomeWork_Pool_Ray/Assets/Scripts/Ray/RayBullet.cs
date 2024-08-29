using System.Collections;
using UnityEngine;

public class RayBullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;

    private int damage;

    private void Start()
    {
        // 총알이 생성된 후 3초 뒤에 삭제되도록 코루틴 시작
        StartCoroutine(DestroyDelay(3f));
    }

    public void SetSpeed(Vector3 speed)
    {
        if (rigid != null)
        {
            rigid.velocity = speed;
        }
    }

    public void SetDamege(int bulletDamage)
    {
        damage = bulletDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        RayTarget target = collision.gameObject.GetComponent<RayTarget>();
        
        if (target != null)
        {
            target.TakeHit(damage);
        }

        Destroy(gameObject);
    }

    private IEnumerator DestroyDelay(float delay)
    {
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(delay);

        // 총알 삭제
        Destroy(gameObject);
    }
}
