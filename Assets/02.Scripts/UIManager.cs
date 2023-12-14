using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text cashTxt;  //SerializeField���༭, ����Ƽ���� ���� Ȱ���� �� �ְ� ����.
    [SerializeField] TMP_Text balanceTxt;

    //���� �Է�
    [SerializeField] TMP_InputField inputValue;
    [SerializeField] TMP_InputField outputValue;

    //�ݾ��� �����մϴ� â.
    [SerializeField] GameObject popupError;

    string FormatNumber(int num)   //���ڿ� ,(��ǥ) �� ��������. õ�� �ڸ����� �޸� ���.
    {
        return string.Format("{0:N0}", num);
    }

    void Refresh()  //�ݾ��� �ٽ� ǥ�������״� �� �Լ� ���.
    {
        cashTxt.text = FormatNumber(MoneyManager.instance.userData.cash);  //���� �����Ϳ� �����ؼ� cash �����ؼ� 
        balanceTxt.text = FormatNumber(MoneyManager.instance.userData.balance);
    }


    //�Ա� ���
    public void Deposit(int money)
    {
        //������ ���ݺ��� �� ���� ���� ���� ���� ����.
        if(money > MoneyManager.instance.userData.cash)
        {
            popupError.SetActive(true); //�ݾ��� �����ϸ� �� â.
            return;
        }

        //�Ա� ����, �̷��� ������ ������ ������ ������ �������� �� �ٲ��� �ʾҴ�.
        //�������� �͵� �˸°� �ٲ�� �ϰ� �ʹٸ� Refresh() �Լ��� ���־���Ѵ�.
        MoneyManager.instance.userData.cash -= money; //������ ���ݸ�ŭ ���ָ� �ǰ���.
        MoneyManager.instance.userData.balance += money; //�� ��ŭ�� ���¿� �־��ֱ�.

        Refresh();
    }

    //��� ���
    public void Withdraw(int money)
    {
        //������ ���ݺ��� �� ���� ���� ���� ���� ����.
        if (money > MoneyManager.instance.userData.balance)
        {
            popupError.SetActive(true); //�ݾ��� �����ϸ� �� â.
            return;
        }

        //�������
        MoneyManager.instance.userData.balance -= money; //�뷱������ ���� ���ְ�.
        MoneyManager.instance.userData.cash += money; //ĳ�ÿ��� ���� �����־�� ��.

        Refresh();
    }

    public void CustomDeposit() //�����Է�, �Ա�
    {
        Deposit(int.Parse(inputValue.text));
    }

    public void CustomWithdraw()    //�����Է�, ���
    {
        Withdraw(int.Parse(outputValue.text));
    }

}
