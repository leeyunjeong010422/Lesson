using UnityEngine;

[CreateAssetMenu(menuName = "Monster", fileName = "Monster")]
public class MonsterData : ScriptableObject
{
    //공유 데이터만 만들기!!
    //public int hp; --> 다른 데이터를 가져야 하는 경우에는 사용 X
    //public int maxHP --> 이건 사용 가능

    //읽기 전용으로 만들어 두는 게 좋음
    [SerializeField] int maxHP;
    public int MaxHP { get { return maxHP; } }

    public int attack;
    public int defense;
    public float speed;
    public float range;

    public Sprite icon;
    public GameObject prefab;
}
