using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text cashTxt;  //SerializeField써줘서, 유니티에서 직접 활당할 수 있게 연결.
    [SerializeField] TMP_Text balanceTxt;

    // Start is called before the first frame update
    void Start()
    {
        cashTxt.text = MoneyManager.instance.userData.cash.ToString();  //유저 데이터에 접근해서 cash 접근해서 
        balanceTxt.text = MoneyManager.instance.userData.balance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
