using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour   
{

    public Text balanceText;
    public GameObject depositPanel; //입금창
    public GameObject insufficientFundsPopup;   // 팝업 창 추가

    private float balance = 100000f;    // 가지고 있는 돈은 100,000원으로 초기화

    private void Start()
    {
        //초기 잔액 설정 등의 초기화 작업 수행.
        UpdateBalanceText();
        //초기에는 입금창을 숨김.
        depositPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);
    }

    public void ShowDepositPanel()
    {
        //입금창을 보이게 함
        depositPanel.SetActive(true);
    }


    public void DepositAmount(float amount)
    {
        if(balance + amount <= 100000f)
        {
            balance += amount;
            UpdateBalanceText();
            //입금 후, 입금창을 숨김
            depositPanel.SetActive(false);
        }
        else
        {
            //가지고 있는 돈을 초과하는 경우에 대한 처리
            ShowInsufficientFundsPopup();
        }
    }



    private void UpdateBalanceText()
    {
        balanceText.text = balance.ToString("   000,000");
    }

    private void ShowInsufficientFundsPopup()
    {
        // 잔액이 부족할 때 팝업 창을 보이게 함
        insufficientFundsPopup.SetActive(true);
    }

    public void CloseInsufficientFundsPopup()
    {
        // 팝업 창을 닫음
        insufficientFundsPopup.SetActive(false);
    }

}
