using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ATM_UI : View
{
    [SerializeField] TMP_Text Client_cash;
    [SerializeField] TMP_Text ATM_name;
    [SerializeField] TMP_Text ATM_balance;
    [SerializeField] Button LackOfMoney;

    public override void Initialize()
    {
        ATM_name.text = BankingManager.Instance.atm.so_ATM.name.ToString();
       
        UpdateFigure();

    }

    public void UpdateFigure()
    {
        Client_cash.text = string.Format("{0:N0}", BankingManager.Instance.client.so_client.cash);
        ATM_balance.text = string.Format("{0:N0}", BankingManager.Instance.atm.so_ATM.balance);
    }

    public void OnEnable()
    {
        BankingManager.Instance.changeFigure += UpdateFigure;
        BankingManager.Instance.LackOfMoney += WarningMassage;
        UIManager.ShowOverride<OptionMenu>();
    }

    private void WarningMassage()
    {
        UIManager.ShowOverride<LackPopup>();
    }

    public void OnDisable()
    {
        BankingManager.Instance.changeFigure -= UpdateFigure;
    }

}
