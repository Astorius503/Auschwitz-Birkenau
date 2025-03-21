using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;

    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.persistentDataPath, "userdata.json");
            LoadUserData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ����
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("���� �Ϸ�: " + savePath);
    }

    // �ҷ�����
    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("�ҷ����� �Ϸ�");
        }
        else
        {
            userData = new UserData("��ƽ�", 50000, 100000);
            SaveUserData();
        }
    }
}


