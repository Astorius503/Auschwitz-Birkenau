using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBankManager : MonoBehaviour
{
    [Header("텍스트 UI")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI walletText;

    [Header("패널")]
    public GameObject mainPanel;
    public GameObject depositPanel;
    public GameObject withdrawPanel;

    [Header("입력 필드")]
    public TMP_InputField depositInput;
    public TMP_InputField withdrawInput;

    private UserData userData;

    void Start()
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)
        {
            Debug.LogError("GameManager 또는 UserData가 초기화되지 않았습니다!");
            return;
        }

        userData = GameManager.Instance.userData;
        ShowMainPanel();
    }

    // 패널 전환용 public 메서드 (OnClick에서 직접 연결)
    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        Refresh();
    }

    public void ShowDepositPanel()
    {
        mainPanel.SetActive(false);
        depositPanel.SetActive(true);
        withdrawPanel.SetActive(false);
        Refresh();
    }

    public void ShowWithdrawPanel()
    {
        mainPanel.SetActive(false);
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(true);
        Refresh();
    }

    // 입금 버튼용 메서드 (int 값을 인스펙터에서 전달 가능)
    public void DepositAmount(int amount)
    {
        if (userData.wallet >= amount)
        {
            userData.wallet -= amount;
            userData.balance += amount;
        }
        Refresh();
    }

    // 출금 버튼용 메서드
    public void WithdrawAmount(int amount)
    {
        if (userData.balance >= amount)
        {
            userData.balance -= amount;
            userData.wallet += amount;
        }
        Refresh();
    }

    // 입력 필드를 통한 입출금
    public void DepositFromInput()
    {
        if (int.TryParse(depositInput.text, out int amount))
        {
            DepositAmount(amount);
        }
    }

    public void WithdrawFromInput()
    {
        if (int.TryParse(withdrawInput.text, out int amount))
        {
            WithdrawAmount(amount);
        }
    }

    // UI 텍스트 갱신
    private void Refresh()
    {
        nameText.text = "사용자: " + userData.GetUserName();
        balanceText.text = "잔액: " + userData.GetFormattedBalance();
        walletText.text = "현금: " + userData.GetFormattedWallet();
    }
}


