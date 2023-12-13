using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour   
{
    public Text balanceText;
    public GameObject depositPanel; //입금창
    public GameObject withdrawPanel;  //출금창
    public GameObject insufficientFundsPopup;   // 팝업 창 추가

    private GameObject previousPanel; // 이전 패널 상태를 저장하기 위한 변수

    private float balance = 100000f;    // 가지고 있는 돈은 100,000원으로 초기화

    private void Start()
    {
        //초기 잔액 설정 등의 초기화 작업 수행.
        UpdateBalanceText();
        // 초기에는 입금창, 출금창, 부족한 잔액 팝업을 숨김
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);
    }

    public void ShowDepositPanel()
    {
        //입금창을 보이게 함
        depositPanel.SetActive(true);
    }

    public void ShowWithdrawPanel()
    {
        //입금창을 보이게 함
        withdrawPanel.SetActive(true);
    }


    public void DepositAmount(float amount) //입금창.
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
    public void WithdrawAmoun(float amount) //출금창.
    {
        if(balance >= amount)
        {
            balance -= amount;
            UpdateBalanceText();
            //출금 후, 출금창을 숨김
            withdrawPanel.SetActive(false);
        }
        else
        {
            //잔액이 부족한 경우에 대한 처리
            ShowInsufficientFundsPopup();
        }
    }

    public void GoBack() //뒤로 가기
    {
        if(previousPanel != null)
        {
            //이전 패널 상태로 복원
            previousPanel.SetActive(true);
        }

        //현재 패널이 depositPanel이라고 가정.
        if (depositPanel != null)
        {
            depositPanel.SetActive(false);
        }
        
        
    }




    private void UpdateBalanceText()    //회색 부분의 현재 금액.
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
