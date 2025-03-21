using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBankManager : MonoBehaviour
{
    [Header("�ؽ�Ʈ UI")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI walletText;

    [Header("�г�")]
    public GameObject mainPanel;
    public GameObject depositPanel;
    public GameObject withdrawPanel;

    [Header("�Է� �ʵ�")]
    public TMP_InputField depositInput;
    public TMP_InputField withdrawInput;

    private UserData userData;

    void Start()
    {
        if (GameManager.Instance == null || GameManager.Instance.userData == null)
        {
            Debug.LogError("GameManager �Ǵ� UserData�� �ʱ�ȭ���� �ʾҽ��ϴ�!");
            return;
        }

        userData = GameManager.Instance.userData;
        ShowMainPanel();
    }

    // �г� ��ȯ�� public �޼��� (OnClick���� ���� ����)
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

    // �Ա� ��ư�� �޼��� (int ���� �ν����Ϳ��� ���� ����)
    public void DepositAmount(int amount)
    {
        if (userData.wallet >= amount)
        {
            userData.wallet -= amount;
            userData.balance += amount;
        }
        Refresh();
    }

    // ��� ��ư�� �޼���
    public void WithdrawAmount(int amount)
    {
        if (userData.balance >= amount)
        {
            userData.balance -= amount;
            userData.wallet += amount;
        }
        Refresh();
    }

    // �Է� �ʵ带 ���� �����
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

    // UI �ؽ�Ʈ ����
    private void Refresh()
    {
        nameText.text = "�����: " + userData.GetUserName();
        balanceText.text = "�ܾ�: " + userData.GetFormattedBalance();
        walletText.text = "����: " + userData.GetFormattedWallet();
    }
}


