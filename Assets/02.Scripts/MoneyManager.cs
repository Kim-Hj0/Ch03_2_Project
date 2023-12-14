using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;    //돈관리를 해줄 예정이기 때문에 싱글톤화.

    public UserData userData;   //유저 데이터

    private void Awake()
    {
        instance = this; 
    }

}
