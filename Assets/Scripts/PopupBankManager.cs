using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // TextMesh Pro 네임스페이스 추가

public class PopupBankManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;   // 이름을 표시할 TextMeshProUGUI
    public TextMeshProUGUI balanceText;  // TextMeshProUGUI로 변경
    public TextMeshProUGUI walletText;   // TextMeshProUGUI로 변경
    public Button depositButton;
    public Button withdrawButton;
    public Button refreshButton;  // 새로고침 버튼 추가

    void Start()
    {
        // GameManager에서 UserData 가져오기
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager 인스턴스가 없습니다!");
            return;  // GameManager가 없으면 실행을 중지
        }

        UserData userData = GameManager.Instance.userData;

        if (userData == null)
        {
            Debug.LogError("UserData가 초기화되지 않았습니다!");
            return;  // userData가 없으면 실행을 중지
        }

        // 이름, 잔액 및 지갑 정보 표시
        UpdateNameDisplay(userData);
        UpdateBalanceDisplay(userData);
        UpdateWalletDisplay(userData);

        // 버튼 클릭 이벤트 설정
        if (depositButton != null)
        {
            depositButton.onClick.AddListener(() => Deposit(userData)); // 입금 버튼 클릭 시 Deposit 메서드 호출
        }
        else
        {
            Debug.LogError("Deposit 버튼이 할당되지 않았습니다!");
        }

        if (withdrawButton != null)
        {
            withdrawButton.onClick.AddListener(() => Withdraw(userData)); // 출금 버튼 클릭 시 Withdraw 메서드 호출
        }
        else
        {
            Debug.LogError("Withdraw 버튼이 할당되지 않았습니다!");
        }

        // 새로고침 버튼 클릭 이벤트 설정
        if (refreshButton != null)
        {
            refreshButton.onClick.AddListener(() => Refresh()); // 새로고침 버튼 클릭 시 Refresh 메서드 호출
        }
        else
        {
            Debug.LogError("Refresh 버튼이 할당되지 않았습니다!");
        }
    }

    void Deposit(UserData userData)
    {
        userData.balance += 10000;  // 입금 예시
        userData.wallet -= 10000;   // 지갑에서 차감
        Refresh();  // UI 업데이트
    }

    void Withdraw(UserData userData)
    {
        userData.balance -= 10000;  // 출금 예시
        userData.wallet += 10000;   // 지갑에 추가
        Refresh();  // UI 업데이트
    }

    // 이름을 화면에 표시
    void UpdateNameDisplay(UserData userData)
    {
        nameText.text = "사용자: " + userData.GetUserName();  // 이름 출력
    }

    void UpdateWalletDisplay(UserData userData)
    {
        walletText.text = "현금: " + userData.GetFormattedWallet();  // 천 단위로 콤마 추가
    }

    void UpdateBalanceDisplay(UserData userData)
    {
        balanceText.text = "잔액: " + userData.GetFormattedBalance();  // 천 단위로 콤마 추가
    }

    // UI 갱신을 위한 Refresh 메소드
    public void Refresh()
    {
        UserData userData = GameManager.Instance.userData;

        if (nameText != null)
        {
            nameText.text = "사용자: " + userData.GetUserName(); // 플레이어 이름 업데이트
        }

        if (balanceText != null)
        {
            balanceText.text = "잔액: " + userData.GetFormattedBalance();  // 계좌 잔고 업데이트
        }

        if (walletText != null)
        {
            walletText.text = "현금: " + userData.GetFormattedWallet(); // 지갑 잔고 업데이트
        }
    }
}

