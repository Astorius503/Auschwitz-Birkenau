using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static GameManager Instance { get; private set; }

    // UserData ����
    public UserData userData;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // �� ���� �ÿ��� GameManager�� �����ǵ��� ����
        }
        else
        {
            Destroy(gameObject);  // �̹� GameManager�� �����ϸ� �� ��ü�� ����
        }
    }

    // Start�� �ʱ�ȭ �ܰ迡�� UserData �ʱ�ȭ
    void Start()
    {
        // ����: �̸� "��ƽ�", ���� 100000, ���� �ܾ� 50000
        userData = new UserData("��ƽ�", 50000, 100000);
    }
}


