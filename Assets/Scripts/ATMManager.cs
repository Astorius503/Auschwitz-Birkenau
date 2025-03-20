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
        // �ʱ� �ܾ� ����
        UpdateBalanceDisplay();
        UpdateWalletDisplay();
        // ��ư Ŭ�� �̺�Ʈ ����
        depositButton.onClick.AddListener(Deposit);
        withdrawButton.onClick.AddListener(Withdraw);
    }

    void Deposit()
    {
        balance += 10000;  // �Ա� ����
        UpdateBalanceDisplay();
        Wallet -= 10000;
        UpdateWalletDisplay();

    }

    void Withdraw()
    {
        balance -= 10000;  // ��� ����
        UpdateBalanceDisplay();
        Wallet += 10000;
        UpdateWalletDisplay();
    }

    void UpdateWalletDisplay()
    {
        walletText.text = "�ܾ�: " + Wallet.ToString("#,0");  // õ ������ �޸� �߰�
    }
    void UpdateBalanceDisplay()
    {
        balanceText.text = "�ܾ�: " + balance.ToString("#,0");  // õ ������ �޸� �߰�
    }
}

