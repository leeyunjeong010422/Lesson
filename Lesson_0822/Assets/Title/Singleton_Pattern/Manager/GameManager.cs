using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//�̱��濡�� ���� �ִ� ������ �巡�׾ص���ϸ� �� ��!!
//�̱����� ���ӿ�����Ʈ�� ������ ���� �ȵ� (find�ؼ� ã�Ƽ� ��� ��)
//������ �̱����� �־��ִ� �� ������� �� �� (�ƴ� ó�� �����ϴ� ������ �־��!!!!!!!)
//�� �̵� �� �����
public class GameManager : MonoBehaviour
{

   // private static GameManager instance = null;
    //public static GameManager Instance { get { return instance; } }

    //�Ʒ� �ڵ� �� �ٷ� �� �ڵ� �� �� ��� ����� �� ����!! ���� �ڵ���
    public static GameManager Instance { get; private set; }

    public int score;

    //public event UnityAction OnStarted;
    //public event UnityAction OnPaused;
    //public event UnityAction OnResumed;
    //public event UnityAction OnFinished;

    //�� �ϳ��� �ν��Ͻ��� ����
    private void Awake()
    {
        //Awake: ó�� ��������� �� ȣ��Ǵ� �Լ�
        //1. �̱����� �������� => ���� ���� �ν��Ͻ��� �̱������� ����
        if (Instance == null)
        {
            Instance = this;

            //���ο� ����ȯ(�ε�)������ �������� �ʴ� ���� ������Ʈ�� ����� ��
            //score�� ���� ���� ��ȯ�ص� ���� �ٲ��� ����
            //���� �ٲ� ������� �ʰ� ����
            //�ٸ� ���� GameManager�� ������ �ʴ��� �״�� �Ű���
            DontDestroyOnLoad(gameObject);
        }
        //2. �̱����� �־����� => ���� ���� �ν��Ͻ��� ��������
        else // (instance != null)�� ��Ȳ
        {
            Destroy(gameObject);
        }
    }

    //�̱��� �����
    public static void Create()
    {
        // Resources ���� : ����Ƽ�� Ư�������� Resources �������� ������ �ڵ� ��θ� ���ؼ� �ε� ����
        // ��, Resources ������ ��������� �ݵ�� ���ԵǴ� �������� �з��ǹǷ� ���Ӻ��������� ũ�⸦ ������Ŵ
        // ����, ������ �Ը� �۰ų� ���ҽ��� ���� ���� �� ��� ���� (���� 6���� �̸��� �������� ������� ��õ)
        // ����, ���¹����̳� ��巹������ ���ؼ� ������ �ʿ䰡 ����

        // Resources.Load<T>(path) : Resources ���� ���� ��ο��� ������ ã�� ������

        GameManager gameManagerPrefab = Resources.Load<GameManager>("Managers/GameManager");
        Instantiate(gameManagerPrefab);
    }

    //�̱��� �����
    public static void Release()
    {
        if(Instance == null)
            return;

        Destroy(Instance.gameObject);
        Instance = null;
    }
}
