using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepositManager : MonoBehaviour
{
    private float balance;
    private Text balanceText;
    private object customAmountInputField;

    public void Initialize(float initialBalance, Text balanceText)
    {
        this.balance = initialBalance;
        this.balanceText = balanceText;
        UpdateBalanceText();
    }

    public void DepositAmount(float amount)
    {
        if (balance + amount <= 100000f)
        {
            balance += amount;
            UpdateBalanceText();
        }
        else
        {
            // 처리 로직 추가 (예: 잔액 부족 팝업 표시)
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

    //사용자 정의 입금 금액에 대한
    public void DepositCustomAmount()
    {
        string customAmountText = GetCustomAmountInput();
        if (float.TryParse(customAmountText, out float customAmount))
        {
            DepositAmount(customAmount);
        }
        else
        {
            //잘못된 입력(숫자가 아닌 경우)
            Debug.LogError("올바른 입력을 해주세요");
        }
    }

    private string GetCustomAmountInput()
    {
        string customAmountText = customAmountInputField.Text;
        if (float.TryParse(customAmountText, out float customAmount))
        {
            DepositAmount(customAmount);
        }
        else
        {
            Debug.LogError("Invalid custom amount input!");

        }
            return "입력한 금액";
    }

    public void DepositCustomAmount(string customAmountText)
    {
        if (!string.IsNullOrEmpty(customAmountText))
        {
            float customAmount = float.Parse(customAmountText);
            DepositAmount(customAmount);
        }
    }

    public void UpdateBalanceText()
    {
        if (balanceText != null)
            balanceText.text = balance.ToString("   000,000");
    }


    internal void CloseInsufficientFundsPopup()
    {
        throw new NotImplementedException();
    }
}



