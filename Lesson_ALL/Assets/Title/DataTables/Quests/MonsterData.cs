using UnityEngine;

[CreateAssetMenu(menuName = "Monster", fileName = "Monster")]
public class MonsterData : ScriptableObject
{
    //���� �����͸� �����!!
    //public int hp; --> �ٸ� �����͸� ������ �ϴ� ��쿡�� ��� X
    //public int maxHP --> �̰� ��� ����

    //�б� �������� ����� �δ� �� ����
    [SerializeField] int maxHP;
    public int MaxHP { get { return maxHP; } }

    public int attack;
    public int defense;
    public float speed;
    public float range;

    public Sprite icon;
    public GameObject prefab;
}
