using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class UserData
{
    public string name;   // ����� �̸�
    public int balance;   // ���� �ܰ�
    public int wallet;    // ���� �ܰ�

    // ������
    public UserData(string userName, int initialBalance, int initialWallet)
    {
        name = userName;   // ����� �̸� �ʱ�ȭ
        balance = initialBalance;
        wallet = initialWallet;
    }

    // �̸� ��ȯ
    public string GetUserName()
    {
        return name;
    }

    // �ܾװ� ���� ������ õ ������ �޸� �߰��Ͽ� ���ڿ��� ��ȯ�ϴ� �޼���
    public string GetFormattedBalance()
    {
        return string.Format("{0:#,0}", balance);
    }

    public string GetFormattedWallet()
    {
        return string.Format("{0:#,0}", wallet);
    }
}

