using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // TextMesh Pro ���ӽ����̽� �߰�

public class PopupBankManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;   // �̸��� ǥ���� TextMeshProUGUI
    public TextMeshProUGUI balanceText;  // TextMeshProUGUI�� ����
    public TextMeshProUGUI walletText;   // TextMeshProUGUI�� ����
    public Button depositButton;
    public Button withdrawButton;
    public Button refreshButton;  // ���ΰ�ħ ��ư �߰�

    void Start()
    {
        // GameManager���� UserData ��������
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager �ν��Ͻ��� �����ϴ�!");
            return;  // GameManager�� ������ ������ ����
        }

        UserData userData = GameManager.Instance.userData;

        if (userData == null)
        {
            Debug.LogError("UserData�� �ʱ�ȭ���� �ʾҽ��ϴ�!");
            return;  // userData�� ������ ������ ����
        }

        // �̸�, �ܾ� �� ���� ���� ǥ��
        UpdateNameDisplay(userData);
        UpdateBalanceDisplay(userData);
        UpdateWalletDisplay(userData);

        // ��ư Ŭ�� �̺�Ʈ ����
        if (depositButton != null)
        {
            depositButton.onClick.AddListener(() => Deposit(userData)); // �Ա� ��ư Ŭ�� �� Deposit �޼��� ȣ��
        }
        else
        {
            Debug.LogError("Deposit ��ư�� �Ҵ���� �ʾҽ��ϴ�!");
        }

        if (withdrawButton != null)
        {
            withdrawButton.onClick.AddListener(() => Withdraw(userData)); // ��� ��ư Ŭ�� �� Withdraw �޼��� ȣ��
        }
        else
        {
            Debug.LogError("Withdraw ��ư�� �Ҵ���� �ʾҽ��ϴ�!");
        }

        // ���ΰ�ħ ��ư Ŭ�� �̺�Ʈ ����
        if (refreshButton != null)
        {
            refreshButton.onClick.AddListener(() => Refresh()); // ���ΰ�ħ ��ư Ŭ�� �� Refresh �޼��� ȣ��
        }
        else
        {
            Debug.LogError("Refresh ��ư�� �Ҵ���� �ʾҽ��ϴ�!");
        }
    }

    void Deposit(UserData userData)
    {
        userData.balance += 10000;  // �Ա� ����
        userData.wallet -= 10000;   // �������� ����
        Refresh();  // UI ������Ʈ
    }

    void Withdraw(UserData userData)
    {
        userData.balance -= 10000;  // ��� ����
        userData.wallet += 10000;   // ������ �߰�
        Refresh();  // UI ������Ʈ
    }

    // �̸��� ȭ�鿡 ǥ��
    void UpdateNameDisplay(UserData userData)
    {
        nameText.text = "�����: " + userData.GetUserName();  // �̸� ���
    }

    void UpdateWalletDisplay(UserData userData)
    {
        walletText.text = "����: " + userData.GetFormattedWallet();  // õ ������ �޸� �߰�
    }

    void UpdateBalanceDisplay(UserData userData)
    {
        balanceText.text = "�ܾ�: " + userData.GetFormattedBalance();  // õ ������ �޸� �߰�
    }

    // UI ������ ���� Refresh �޼ҵ�
    public void Refresh()
    {
        UserData userData = GameManager.Instance.userData;

        if (nameText != null)
        {
            nameText.text = "�����: " + userData.GetUserName(); // �÷��̾� �̸� ������Ʈ
        }

        if (balanceText != null)
        {
            balanceText.text = "�ܾ�: " + userData.GetFormattedBalance();  // ���� �ܰ� ������Ʈ
        }

        if (walletText != null)
        {
            walletText.text = "����: " + userData.GetFormattedWallet(); // ���� �ܰ� ������Ʈ
        }
    }
}

