using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text cashTxt;  //SerializeField써줘서, 유니티에서 직접 활당할 수 있게 연결.
    [SerializeField] TMP_Text balanceTxt;

    //직접 입력
    [SerializeField] TMP_InputField inputValue;
    [SerializeField] TMP_InputField outputValue;

    //금액이 부족합니다 창.
    [SerializeField] GameObject popupError;

    string FormatNumber(int num)   //숫자에 ,(쉼표) 를 넣으려면. 천의 자리마다 콤마 찍기.
    {
        return string.Format("{0:N0}", num);
    }

    void Refresh()  //금액을 다시 표현해줄테는 이 함수 사용.
    {
        cashTxt.text = FormatNumber(MoneyManager.instance.userData.cash);  //유저 데이터에 접근해서 cash 접근해서 
        balanceTxt.text = FormatNumber(MoneyManager.instance.userData.balance);
    }


    //입금 기능
    public void Deposit(int money)
    {
        //보유한 현금보다 더 많은 돈을 넣을 수가 없다.
        if(money > MoneyManager.instance.userData.cash)
        {
            popupError.SetActive(true); //금액이 부족하면 뜰 창.
            return;
        }

        //입금 절차, 이렇게 적으면 정보는 수정된 거지만 보여지는 건 바뀌지 않았다.
        //보여지는 것도 알맞게 바뀌게 하고 싶다면 Refresh() 함수를 써주어야한다.
        MoneyManager.instance.userData.cash -= money; //보유한 현금만큼 빼주면 되겠죠.
        MoneyManager.instance.userData.balance += money; //뺀 만큼을 계좌에 넣어주기.

        Refresh();
    }

    //출금 기능
    public void Withdraw(int money)
    {
        //보유한 현금보다 더 많은 돈을 넣을 수가 없다.
        if (money > MoneyManager.instance.userData.balance)
        {
            popupError.SetActive(true); //금액이 부족하면 뜰 창.
            return;
        }

        //출금절차
        MoneyManager.instance.userData.balance -= money; //밸런스에서 돈을 빼주고.
        MoneyManager.instance.userData.cash += money; //캐시에서 돈을 더해주어야 함.

        Refresh();
    }

    public void CustomDeposit() //직접입력, 입금
    {
        Deposit(int.Parse(inputValue.text));
    }

    public void CustomWithdraw()    //직접입력, 출금
    {
        Withdraw(int.Parse(outputValue.text));
    }

}
