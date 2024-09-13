using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]

public struct WeaponData
{
    public int index;
    public string name;
    public int attack;
    public int defense;
    public string description;
}

public class CSVParser : MonoBehaviour
{

    [SerializeField] List<WeaponData> weapons;
    public Dictionary<int, WeaponData> weaponDatas = new Dictionary<int, WeaponData>();

    private void Awake()
    {
        //#if UNITY_EDITOR
        //        //dataPath: ������Ʈ ��� => ���� ���� �߿� ���
        //        string path = Application.dataPath;
        //#else
        //        //persistentDataPath: ?
        //        string Path = Application.persistentDataPath;
        //#endif

        //��ΰ� �����ϴ���? T/F
        //bool exist = Directory.Exists(path);
        //Debug.Log(exist);

        //*: ����͵� �������
        //csv ���ϸ� ã��
        //string[] files = Directory.GetFiles(path, "*.csv");

        //foreach (string file in files)
        //{
        //    Debug.Log(file);
        //}

        //dataPath: ������Ʈ ��� => ���� ���� �߿� ���
        string path = $"{Application.dataPath}/Title/DataTables";
        //Debug.Log(path);

        if (Directory.Exists(path) == false)
        {
            Debug.Log("��ΰ� �����ϴ�.");
        }

        if (File.Exists($"{path}/datatable.csv") == false)
        {
            Debug.Log("������ �����ϴ�");
        }

        string file = File.ReadAllText($"{path}/datatable.csv");

        //�о� ���� ������ �ٷ� ����
        //���� ���� ���
        string[] lines = file.Split('\n');
        for (int y = 1; y < lines.Length; y++)
        {
            WeaponData weaponData = new WeaponData();

            string[] values = lines[y].Split(',', '\t');

            weaponData.index = int.Parse(values[0]);
            weaponData.name = values[1];
            weaponData.attack = int.Parse(values[2]);
            weaponData.defense = int.Parse(values[3]);
            weaponData.description = values[4];

            weapons.Add(weaponData);
            weaponDatas.Add(weaponData.index, weaponData);

        }
    }
}

//�̷������� ������ �����ͼ� ����� �� ���� (�̱������� ������� ��)
//public class Weapon : MonoBehaviour
//{
//    public int id;
//    public int attack => Manager.Data.WeaponData[id].attack;.

//    private void Start()
//    {

//    }
//}
