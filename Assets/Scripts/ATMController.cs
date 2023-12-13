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

    private GameObject previousPanel; // ���� �г� ���¸� �����ϱ� ���� ����

    private float balance = 100000f;    // ������ �ִ� ���� 100,000������ �ʱ�ȭ

    private void Start()
    {
        //�ʱ� �ܾ� ���� ���� �ʱ�ȭ �۾� ����.
        UpdateBalanceText();
        // �ʱ⿡�� �Ա�â, ���â, ������ �ܾ� �˾��� ����
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);
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
            //�Ա� ��, �Ա�â�� ����
            depositPanel.SetActive(false);
        }
        else
        {
            //������ �ִ� ���� �ʰ��ϴ� ��쿡 ���� ó��
            ShowInsufficientFundsPopup();
        }
    }
    public void WithdrawAmoun(float amount) //���â.
    {
        if(balance >= amount)
        {
            balance -= amount;
            UpdateBalanceText();
            //��� ��, ���â�� ����
            withdrawPanel.SetActive(false);
        }
        else
        {
            //�ܾ��� ������ ��쿡 ���� ó��
            ShowInsufficientFundsPopup();
        }
    }

    public void GoBack() //�ڷ� ����
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




    private void UpdateBalanceText()    //ȸ�� �κ��� ���� �ݾ�.
    {
        balanceText.text = balance.ToString("   000,000");
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
