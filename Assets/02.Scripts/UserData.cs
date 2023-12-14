using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData_", menuName = "ATM Data/UserData", order = 0)]
public class UserData : ScriptableObject    //ScriptableObject를 작성하면 Start, Update를 쓰지 않아도 됨.
{
    public int cash;
    public int balance;
}
