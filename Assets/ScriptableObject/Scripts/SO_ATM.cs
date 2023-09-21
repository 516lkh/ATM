using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultATMData", menuName = "Back/ATM", order = 1)]
public class SO_ATM : ScriptableObject
{
    [Header("ATMBalance")]
    public int Balance;

}
