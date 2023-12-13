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

        mainMenuPanel.SetActive(true);//�߰�


        UpdateBalanceText();//�߰�

    }

    public void ShowDepositPanel()
    {
        //�Ա�â�� ���̰� ��
        depositPanel.SetActive(true);
        previousPanel = mainMenuPanel;//�߰�
        mainMenuPanel.SetActive(false);
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
            //balance += amount;
            //UpdateBalanceText();
            ////�Ա� ��, �Ա�â�� ����
            //depositPanel.SetActive(false);

            depositManager.DepositAmount(amount);
            depositPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        //}
        //else
        //{
        //    //������ �ִ� ���� �ʰ��ϴ� ��쿡 ���� ó��
        //    ShowInsufficientFundsPopup();
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

    public void DepositCustomAmount()//�߰�.
    {
        string customAmountText = GetCustomAmountInput(); // ����ڰ� ���� �Է��� ���� ���������� �����ؾ� �մϴ�.
        depositManager.DepositCustomAmount(customAmountText);
        depositPanel.SetActive(false);
        mainMenuPanel.SetActive(true);//�߰�.
    }

    private void UpdateBalanceText()//�߰�
    {
        depositManager.UpdateBalanceText();//�߰�
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
        // ���⿡ ����ڰ� ���� �Է��� ���� �������� ������ �߰��ϼ���.
        // Unity UI�� InputField ���� ����Ͽ� ���� �Է¹��� �� �ֽ��ϴ�.
        // ����� �ӽ÷� "�Է��� �ݾ�"���� ��ü�Ͽ����ϴ�.
        return "�Է��� �ݾ�";
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

    public void GoBackWithdrawal() 
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

    //private void UpdateBalanceText()    //ȸ�� �κ��� ���� �ݾ�.
    //{
    //    balanceText.text = balance.ToString("   000,000");
    //}

    //private void ShowInsufficientFundsPopup()
    //{
    //    // �ܾ��� ������ �� �˾� â�� ���̰� ��
    //    insufficientFundsPopup.SetActive(true);
    //}

    public void CloseInsufficientFundsPopup()
    {
        // �˾� â�� ����
        insufficientFundsPopup.SetActive(false);
    }

}
