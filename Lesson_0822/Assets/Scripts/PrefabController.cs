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
        //생성
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Instantiate(어떤 프리팹으로 만들건지, 위치, 회전)
            //gameObjInstance = Instantiate(SnowManPrefab, transform.position, transform.rotation);

            rigidInstance = Instantiate(rigidPrefab, transform.position, transform.rotation);
            rigidInstance.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

        //삭제
        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(target, 3);
        }
    }
}
