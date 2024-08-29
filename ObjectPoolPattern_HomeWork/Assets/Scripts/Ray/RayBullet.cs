using UnityEngine;

public class RayBullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;

    private int damage;

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
}
