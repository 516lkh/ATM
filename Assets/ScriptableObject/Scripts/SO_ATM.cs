using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultATMData", menuName = "Back/ATM", order = 1)]
public class SO_ATM : ScriptableObject
{
    [Header("ClientInfo")]
    public string name;
    public int balance;

    [Header("Unit")]
    public int option1;
    public int option2;
    public int option3;

}
