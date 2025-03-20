using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    // UserData 변수
    public UserData userData;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 변경 시에도 GameManager가 유지되도록 설정
        }
        else
        {
            Destroy(gameObject);  // 이미 GameManager가 존재하면 이 객체를 삭제
        }
    }

    // Start나 초기화 단계에서 UserData 초기화
    void Start()
    {
        // 예시: 이름 "김아스", 현금 100000, 통장 잔액 50000
        userData = new UserData("김아스", 50000, 100000);
    }
}


