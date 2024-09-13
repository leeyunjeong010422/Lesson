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
        //        //dataPath: 프로젝트 경로 => 게임 제작 중에 사용
        //        string path = Application.dataPath;
        //#else
        //        //persistentDataPath: ?
        //        string Path = Application.persistentDataPath;
        //#endif

        //경로가 존재하는지? T/F
        //bool exist = Directory.Exists(path);
        //Debug.Log(exist);

        //*: 어느것도 상관없다
        //csv 파일만 찾음
        //string[] files = Directory.GetFiles(path, "*.csv");

        //foreach (string file in files)
        //{
        //    Debug.Log(file);
        //}

        //dataPath: 프로젝트 경로 => 게임 제작 중에 사용
        string path = $"{Application.dataPath}/Title/DataTables";
        //Debug.Log(path);

        if (Directory.Exists(path) == false)
        {
            Debug.Log("경로가 없습니다.");
        }

        if (File.Exists($"{path}/datatable.csv") == false)
        {
            Debug.Log("파일이 없습니다");
        }

        string file = File.ReadAllText($"{path}/datatable.csv");

        //읽어 들인 파일을 줄로 나눔
        //한줄 한줄 출력
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

//이런식으로 언제나 가져와서 사용할 수 있음 (싱글톤으로 만들었을 때)
//public class Weapon : MonoBehaviour
//{
//    public int id;
//    public int attack => Manager.Data.WeaponData[id].attack;.

//    private void Start()
//    {

//    }
//}
