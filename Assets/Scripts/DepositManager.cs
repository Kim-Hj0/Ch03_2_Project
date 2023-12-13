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
            // ó�� ���� �߰� (��: �ܾ� ���� �˾� ǥ��)
        }
    }

    public void Deposit10000()  //�߰�
    {
        DepositAmount(10000);
    }

    public void Deposit50000()//�߰�
    {
        DepositAmount(50000);
    }

    public void Deposit30000()//�߰�
    {
        DepositAmount(30000);
    }

    //����� ���� �Ա� �ݾ׿� ����
    public void DepositCustomAmount()
    {
        string customAmountText = GetCustomAmountInput();
        if (float.TryParse(customAmountText, out float customAmount))
        {
            DepositAmount(customAmount);
        }
        else
        {
            //�߸��� �Է�(���ڰ� �ƴ� ���)
            Debug.LogError("�ùٸ� �Է��� ���ּ���");
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
            return "�Է��� �ݾ�";
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



