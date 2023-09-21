using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultClientData", menuName = "World/Client", order = 0)]
public class SO_Client : ScriptableObject
{
    [Header("ClientInfo")]
    public string name;

    [Header("ClientCash")]
    public int cash;

}
