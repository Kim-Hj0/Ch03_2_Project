using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMController : MonoBehaviour   
{

    public Text balanceText;
    public GameObject depositPanel; //�Ա�â
    public GameObject insufficientFundsPopup;   // �˾� â �߰�

    private float balance = 100000f;    // ������ �ִ� ���� 100,000������ �ʱ�ȭ

    private void Start()
    {
        //�ʱ� �ܾ� ���� ���� �ʱ�ȭ �۾� ����.
        UpdateBalanceText();
        //�ʱ⿡�� �Ա�â�� ����.
        depositPanel.SetActive(false);
        insufficientFundsPopup.SetActive(false);
    }

    public void ShowDepositPanel()
    {
        //�Ա�â�� ���̰� ��
        depositPanel.SetActive(true);
    }


    public void DepositAmount(float amount)
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



    private void UpdateBalanceText()
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
