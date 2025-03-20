using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class UserData
{
    public string name;   // 사용자 이름
    public int balance;   // 통장 잔고
    public int wallet;    // 지갑 잔고

    // 생성자
    public UserData(string userName, int initialBalance, int initialWallet)
    {
        name = userName;   // 사용자 이름 초기화
        balance = initialBalance;
        wallet = initialWallet;
    }

    // 이름 반환
    public string GetUserName()
    {
        return name;
    }

    // 잔액과 지갑 정보를 천 단위로 콤마 추가하여 문자열로 반환하는 메서드
    public string GetFormattedBalance()
    {
        return string.Format("{0:#,0}", balance);
    }

    public string GetFormattedWallet()
    {
        return string.Format("{0:#,0}", wallet);
    }
}

