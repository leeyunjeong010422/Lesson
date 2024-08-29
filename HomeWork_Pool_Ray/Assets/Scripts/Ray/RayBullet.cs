using System.Collections;
using UnityEngine;

public class RayBullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;

    private int damage;

    private void Start()
    {
        // �Ѿ��� ������ �� 3�� �ڿ� �����ǵ��� �ڷ�ƾ ����
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
        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(delay);

        // �Ѿ� ����
        Destroy(gameObject);
    }
}
