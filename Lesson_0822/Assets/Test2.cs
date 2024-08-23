using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    //[����ȭ [SerializeField]]
    //������ ���� �Ǵ� ���� ������Ʈ ���¸� �����ϰ� �����ϴ� ���
    //�ν����� â���� ������Ʈ�� ����ȭ�� ������� ���� ������
    //�̸� �̿��Ͽ� �ҽ��ڵ��� ���� ���� ����Ƽ �����Ϳ��� ���� ���� ����

    //<������ ����ȭ>
    //������Ʈ�� ������� ���� Ȯ���ϰų� ����
    //������Ʈ�� ������� ������ �巡�� �� ��� ������� ����

    [Header("Value Type")]
    //C# Type (int, bool, float, string)
    public int value;

    //Unity Type
    public Vector3 vector3; //X,Y,Z�� �־��� �� ����
    public Vector2 vector2; //X,Y�� �־��� �� ����
    public Vector3Int Vector3Int; //�Ҽ��� X
    public Vector2Int Vector2Int; //�Ҽ��� X
    public Color color; //���� ���� ����

    public Rect rect; //�簢��
    public LayerMask layerMask;
    public AnimationCurve curve;
    public Gradient Gradient;

    //������
    public enum JobType { a, b, c }
    public JobType jobType;

    //�迭 ��� �ڷᱸ��
    public int[] array;
    public List<JobType> list;

    [Header("Reference Type")]
    //�巡��
    public Rigidbody rigid;
    public Collider coll;

    //[��Ʈ����Ʈ]
    //Ŭ����, �Ӽ� �Ǵ� �Լ� ���� ����Ͽ� Ư���� ������ ��Ÿ�� �� �ִ� ��Ŀ
    [Space(30)]

    [Header("Unity Attribute")]
    [SerializeField] int privateValue; //private�ε� ���̰� �ϱ�
    [HideInInspector] public int publicValue; //public�ε� �� ���̰� �ϱ�

    [Range(3, 5)]
    public float percent = 4; //������ ������ �༭ �ּ� �ִ븦 ������ ����

    [TextArea(3, 5)]
    public string story; //�� �ۼ� ���� ����

    [System.Serializable]
    public struct Data
    {
        public string name;
        public int level;
        public float rate;
    }
    public Data data; //[System.Serializable] �̰� �� ��� ����Ƽ���� �� �� ����

    [System.Serializable]
    public class ClassType
    {
        public string name;
        public int level;
        public float rate;
    }
    public ClassType refer;


    //[����Ƽ �޽��� �Լ�]
    //����Ƽ�� ������ �޽����� �����ϴ� �Լ�
    //MonoBehaviour Ŭ������ �޽����� ���� �̸��� �Լ��� ���� (MonoBehaviour �̰� ������ �� ��)
    //��ũ��Ʈ�� ����Ƽ ������ ������ �޽����� �޾� ��� Ÿ�̹��� Ȯ��
    //�޽��� �Լ����� �ڽ��� �ൿ�� �����Ͽ� ����� ����

    private void Awake()
    {
        Debug.Log("Start���� ����!");
        //��ũ��Ʈ�� ���� ���ԵǾ��� �� 1ȸ ȣ��
        //��ũ��Ʈ�� ��Ȱ��ȭ �Ǿ� �ִ� ��쿡�� ȣ��
        //����: ��ũ��Ʈ�� �ʿ�� �ϴ� �ʱ�ȭ �۾� ���� (�ܺ� ���ӻ�Ȳ�� ������ �ʱ�ȭ �۾�)
        //start���� �׻� ���� ȣ��!! 
        //���� �����ϴ� ���� ���� �غ��ؾ� �ϴ� �� (����� ó�����δٰ� �����ϴ� �������� �غ��ϰ� �ϴ� ��)
        //���� ���� Awake�� ���� �غ��ϴ� �Ű� Start�� Awake�� �ٵ� �غ� �Ǿ� ���� �� �����ϴ� ��!!
    }
    private void Start()
    {
        Debug.Log("�����ϸ�!");
        //��ũ��Ʈ�� ���� ó������ Update�ϱ� ������ 1ȸ ȣ��
        //��ũ��Ʈ�� ��Ȱ��ȭ �Ǿ� �ִ� ��� ȣ����� ����
        //����: ��ũ��Ʈ�� �ʿ�� �ϴ� �ʱ�ȭ �۾� ���� (�ܺ� ���ӻ�Ȳ�� �ʿ��� �ʱ�ȭ �۾�)
        //�����ϱ� ���� �غ��ؾ� �ϴ� �͵��̱� ������ �ٵ� �غ�Ǿ��� �� �����ϴ� ��
    }

    private void Update()
    {
        Debug.Log("������ ������! (����)");
        //������ ������ ȣ��
        //����: �ٽ� ���� ���� ����
    }

    private void OnEnable()
    {
        Debug.Log("Ȱ��ȭ �Ǹ�!");
        //��ũ��Ʈ�� Ȱ��ȭ�� ������ ȣ��
        //����: ��ũ��Ʈ�� Ȱ��ȭ �Ǿ��� �� �۾� ����
    }

    private void OnDisable()
    {
        Debug.Log("��Ȱ��ȭ �Ǹ�!");
        //��ũ��Ʈ�� ��Ȱ��ȭ�� ������ ȣ��
        //����: ��ũ��Ʈ�� ��Ȱ��ȭ �Ǿ��� �� �۾� ����
    }

    private void OnDestroy()
    {
        //��ũ��Ʈ�� ������ �����Ǿ��� �� 1ȸ ȣ��
        //����: ��ũ��Ʈ�� �ʿ�� �ϴ� ������ �۾� ����
        Debug.Log("���� �Ǹ�!");
    }
}
