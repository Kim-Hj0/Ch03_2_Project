using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepositManager : MonoBehaviour
{
    private float balance;
    private Text balanceText;

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



