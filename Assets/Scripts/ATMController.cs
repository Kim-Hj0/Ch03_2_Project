using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour   
{
    public Text balanceText;
    public GameObject depositPanel; //�Ա�â
    public GameObject withdrawPanel;  //���â
    public GameObject insufficientFundsPopup;   // �˾� â �߰�
    
    public GameObject mainMenuPanel; //�߰�
    private DepositManager depositManager;//�߰�

    private GameObject previousPanel; // ���� �г� ���¸� �����ϱ� ���� ����


    private float balance = 100000f;    // ������ �ִ� ���� 100,000������ �ʱ�ȭ

    private void Start()
    {
        depositManager = gameObject.AddComponent<DepositManager>();//�߰�
        depositManager.Initialize(100000f, balanceText);//�߰�

        //�ʱ� �ܾ� ���� ���� �ʱ�ȭ �۾� ����.
        UpdateBalanceText();
        // �ʱ⿡�� �Ա�â, ���â, ������ �ܾ� �˾��� ����
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);//�߰�


        UpdateBalanceText();//�߰�

    }

    public void ShowDepositPanel()
    {
        //�Ա�â�� ���̰� ��
        depositPanel.SetActive(true);
    }

    public void ShowWithdrawPanel()
    {
        //�Ա�â�� ���̰� ��
        withdrawPanel.SetActive(true);
    }


    public void DepositAmount(float amount) //�Ա�â.
    {
        if(balance + amount <= 100000f)
        {
            balance += amount;
            UpdateBalanceText();
            depositPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            
        }
        else
        {
           //������ �ִ� ���� �ʰ��ϴ� ��쿡 ���� ó��
            ShowInsufficientFundsPopup();
        }
    }


    public void BackButton()
    {
        depositManager.CloseInsufficientFundsPopup();
        withdrawPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    //public void WithdrawAmoun(float amount) //���â.
    //{
    //    if(balance >= amount)
    //    {
    //        balance -= amount;
    //        UpdateBalanceText();
    //        //��� ��, ���â�� ����
    //        withdrawPanel.SetActive(false);
    //    }
    //    else
    //    {
    //        //�ܾ��� ������ ��쿡 ���� ó��
    //        ShowInsufficientFundsPopup();
    //    }
    //}

    public void GoBack() //�Ա�â���� �ڷ� ����
    {
        if(previousPanel != null)
        {
            //���� �г� ���·� ����
            previousPanel.SetActive(true);
        }

        //���� �г��� depositPanel�̶�� ����.
       if (depositPanel != null)
        {
            depositPanel.SetActive(false);
        }     
    }

    public void GoBackWithdrawal() //���â���� �ڷ� ����
    {
        if(previousPanel != null)
        {
            //���� �г� ���·� ����
            previousPanel.SetActive(true);
        }

        if (withdrawPanel != null)
        {
            withdrawPanel.SetActive(false);
        }

    }

    private void UpdateBalanceText()    //ȸ�� �κ��� ���� �ݾ�.
    {
        balanceText.text = balance.ToString("C");
    }

    private void ShowInsufficientFundsPopup()
    {
        // �ܾ��� ������ �� �˾� â�� ���̰� ��
        insufficientFundsPopup.SetActive(true);
    }


    public void CloseInsufficientFundsPopup()
    {
        // �˾� â�� ����
        insufficientFundsPopup.SetActive(false);
    }

}
