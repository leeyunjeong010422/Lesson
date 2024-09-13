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
    //    string json = "{\"name\":\"������\",\"level\":1,\"rate\":0.5}";
    //    gameData = JsonUtility.FromJson<GameData>(json);
    //}

    [ContextMenu("Save")]
    public void Save()
    {
        string path = $"{Application.dataPath}/Save";

        //���丮�� ������ ������ ���ΰ� ������ ����
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }

        //���ӵ����͸� json���·� �ٲ�
        //txt ���·� ������ �� ����
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText($"{path}/save.txt", json );
    }

    [ContextMenu("Load")]
    private void Load()
    {
        string path = $"{Application.dataPath}/Save/save.txt";

        //������ �ִ��� ������
        if (File.Exists(path) == false)
        {
            Debug.Log("�ҷ��� ���̺� ������ ����");
            return;
        }

        //����Ǿ� �ִ� �����͸� �ҷ��� (�ؽ�Ʈ ���¸� �о��)
        string json = File.ReadAllText(path);
        gameData = JsonUtility.FromJson<GameData>(json);
    }
}
