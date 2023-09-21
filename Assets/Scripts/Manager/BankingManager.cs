using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BankingManager : MonoBehaviour
{
    public static BankingManager Instance;

    public Client client;
    public ATM atm;

    public event Action changeFigure;

    public event Action LackOfMoney;

    public void Awake()
    {
        Instance = this;
        client = GetComponent<Client>();
        atm = GetComponent<ATM>();
    }

    public void Deposit(int cash)
    {
        if (client.so_client.cash < cash)
        {
            LackOfMoney?.Invoke();
            return;
        }
        client.so_client.cash -= cash;
        atm.so_ATM.balance += cash;

        changeFigure?.Invoke();
    }

    public void Withdraw(int cash)
    {
        if (atm.so_ATM.balance < cash)
        {
            LackOfMoney?.Invoke();
            return;
        }
        atm.so_ATM.balance -= cash;
        client.so_client.cash += cash;

        changeFigure?.Invoke();
    }

}
