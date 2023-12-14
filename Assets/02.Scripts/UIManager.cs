using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text cashTxt;  //SerializeField���༭, ����Ƽ���� ���� Ȱ���� �� �ְ� ����.
    [SerializeField] TMP_Text balanceTxt;

    // Start is called before the first frame update
    void Start()
    {
        cashTxt.text = MoneyManager.instance.userData.cash.ToString();  //���� �����Ϳ� �����ؼ� cash �����ؼ� 
        balanceTxt.text = MoneyManager.instance.userData.balance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
