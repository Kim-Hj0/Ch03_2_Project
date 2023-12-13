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
    
    public GameObject mainMenuPanel; //추가
    private DepositManager depositManager;//추가

    private GameObject previousPanel; // 이전 패널 상태를 저장하기 위한 변수



    private float balance = 100000f;    // 가지고 있는 돈은 100,000원으로 초기화

    private void Start()
    {
        depositManager = gameObject.AddComponent<DepositManager>();//추가
        depositManager.Initialize(100000f, balanceText);//추가

        //초기 잔액 설정 등의 초기화 작업 수행.
        UpdateBalanceText();
        // 초기에는 입금창, 출금창, 부족한 잔액 팝업을 숨김
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);//추가

        mainMenuPanel.SetActive(true);//추가


        UpdateBalanceText();//추가

    }

    public void ShowDepositPanel()
    {
        //입금창을 보이게 함
        depositPanel.SetActive(true);
        previousPanel = mainMenuPanel;//추가
        mainMenuPanel.SetActive(false);
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
            //balance += amount;
            //UpdateBalanceText();
            ////입금 후, 입금창을 숨김
            //depositPanel.SetActive(false);

            depositManager.DepositAmount(amount);
            depositPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        //}
        //else
        //{
        //    //가지고 있는 돈을 초과하는 경우에 대한 처리
        //    ShowInsufficientFundsPopup();
        }
    }

    public void Deposit10000()  //추가
    {
        DepositAmount(10000);
    }

    public void Deposit50000()//추가
    {
        DepositAmount(50000);
    }

    public void Deposit30000()//추가
    {
        DepositAmount(30000);
    }

    public void DepositCustomAmount()//추가.
    {
        string customAmountText = GetCustomAmountInput(); // 사용자가 직접 입력한 값을 가져오도록 수정해야 합니다.
        depositManager.DepositCustomAmount(customAmountText);
        depositPanel.SetActive(false);
        mainMenuPanel.SetActive(true);//추가.
    }

    private void UpdateBalanceText()//추가
    {
        depositManager.UpdateBalanceText();//추가
    }

    private void ShowInsufficientFundsPopup()
    {
        insufficientFundsPopup.SetActive(true);
    }

    

    public void BackButton()
    {
        depositManager.CloseInsufficientFundsPopup();
        withdrawPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private string GetCustomAmountInput()
    {
        // 여기에 사용자가 직접 입력한 값을 가져오는 로직을 추가하세요.
        // Unity UI의 InputField 등을 사용하여 값을 입력받을 수 있습니다.
        // 현재는 임시로 "입력한 금액"으로 대체하였습니다.
        return "입력한 금액";
    }




    //public void WithdrawAmoun(float amount) //출금창.
    //{
    //    if(balance >= amount)
    //    {
    //        balance -= amount;
    //        UpdateBalanceText();
    //        //출금 후, 출금창을 숨김
    //        withdrawPanel.SetActive(false);
    //    }
    //    else
    //    {
    //        //잔액이 부족한 경우에 대한 처리
    //        ShowInsufficientFundsPopup();
    //    }
    //}

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

    public void GoBackWithdrawal() 
    {
        if(previousPanel != null)
        {
            //이전 패널 상태로 복원
            previousPanel.SetActive(true);
        }

        if (withdrawPanel != null)
        {
            withdrawPanel.SetActive(false);
        }

    }

    //private void UpdateBalanceText()    //회색 부분의 현재 금액.
    //{
    //    balanceText.text = balance.ToString("   000,000");
    //}

    //private void ShowInsufficientFundsPopup()
    //{
    //    // 잔액이 부족할 때 팝업 창을 보이게 함
    //    insufficientFundsPopup.SetActive(true);
    //}

    public void CloseInsufficientFundsPopup()
    {
        // 팝업 창을 닫음
        insufficientFundsPopup.SetActive(false);
    }

}
