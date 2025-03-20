using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ATMManager : MonoBehaviour
{
    public TextMeshProUGUI balanceText;  
    public TextMeshProUGUI walletText;
    public Button depositButton;
    public Button withdrawButton;
    private int balance = 50000;
    private int Wallet = 100000;

    void Start()
    {
        // 초기 잔액 설정
        UpdateBalanceDisplay();
        UpdateWalletDisplay();
        // 버튼 클릭 이벤트 설정
        depositButton.onClick.AddListener(Deposit);
        withdrawButton.onClick.AddListener(Withdraw);
    }

    void Deposit()
    {
        balance += 10000;  // 입금 예시
        UpdateBalanceDisplay();
        Wallet -= 10000;
        UpdateWalletDisplay();

    }

    void Withdraw()
    {
        balance -= 10000;  // 출금 예시
        UpdateBalanceDisplay();
        Wallet += 10000;
        UpdateWalletDisplay();
    }

    void UpdateWalletDisplay()
    {
        walletText.text = "잔액: " + Wallet.ToString("#,0");  // 천 단위로 콤마 추가
    }
    void UpdateBalanceDisplay()
    {
        balanceText.text = "잔액: " + balance.ToString("#,0");  // 천 단위로 콤마 추가
    }
}

