using UnityEngine;

public class PrefabController : MonoBehaviour
{
    //[SerializeField] GameObject SnowManPrefab;
    [SerializeField] Rigidbody rigidPrefab;

    //[SerializeField] GameObject gameObjInstance;
    [SerializeField] Rigidbody rigidInstance;
    [SerializeField] GameObject target;

    private void Update()
    {
        //����
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Instantiate(� ���������� �������, ��ġ, ȸ��)
            //gameObjInstance = Instantiate(SnowManPrefab, transform.position, transform.rotation);

            rigidInstance = Instantiate(rigidPrefab, transform.position, transform.rotation);
            rigidInstance.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

        //����
        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(target, 3);
        }
    }
}
