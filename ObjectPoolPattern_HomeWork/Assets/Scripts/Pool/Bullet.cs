using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] PooledObject pooledObject;
    [SerializeField] float moveSpeed;
    [SerializeField] float returnTime;

    private float remainTime;

    public void OnEnable()
    {
        remainTime = returnTime;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        remainTime -= Time.deltaTime;
        if (remainTime < 0)
        {
            pooledObject.ReturnToPool();
        }
    }
}
