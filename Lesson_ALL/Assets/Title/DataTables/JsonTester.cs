using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string name;
    public int level;
    public float rate;
}
public class JsonTester : MonoBehaviour
{
    [SerializeField] GameData gameData;

    //private void Start()
    //{
    //    //string json = JsonUtility.ToJson(gameData);
    //    string json = "{\"name\":\"김전사\",\"level\":1,\"rate\":0.5}";
    //    gameData = JsonUtility.FromJson<GameData>(json);
    //}

    [ContextMenu("Save")]
    public void Save()
    {
        string path = $"{Application.dataPath}/Save";

        //디렉토리에 폴더가 있으면 냅두고 없으면 만듦
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }

        //게임데이터를 json형태로 바꿈
        //txt 형태로 저장할 수 있음
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText($"{path}/save.txt", json );
    }

    [ContextMenu("Load")]
    private void Load()
    {
        string path = $"{Application.dataPath}/Save/save.txt";

        //파일이 있는지 없는지
        if (File.Exists(path) == false)
        {
            Debug.Log("불러올 세이브 파일이 없음");
            return;
        }

        //저장되어 있던 데이터를 불러옴 (텍스트 형태를 읽어옴)
        string json = File.ReadAllText(path);
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
