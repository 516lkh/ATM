using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject CashFigure;
    public GameObject AccountFigure;
    public GameObject Option;
    public GameObject WithDraw;
    public GameObject Deposit;
    public GameObject LackPopup;

    private TMP_Text Cash;
    private TMP_Text Account;

    public TMP_InputField inputCash;
    public TMP_InputField inputAccount;

    private void Awake()
    {
        Cash = CashFigure.GetComponent<TMP_Text>();
        Account = AccountFigure.GetComponent<TMP_Text>();
    }

    public void PushWithDraw()
    {
        Option.gameObject.SetActive(false);
        WithDraw.gameObject.SetActive(true);
    }

    public void PushDeposit()
    {
        Option.gameObject.SetActive(false);
        Deposit.gameObject.SetActive(true);
    }

    public void PushOption()
    {
        WithDraw.gameObject.SetActive(false);
        Deposit.gameObject.SetActive(false);
        Option.gameObject.SetActive(true);
    }

    public void PushLackPopup()
    {
        LackPopup.gameObject.SetActive(true);
    }

    public void PopLackPopup()
    {
        LackPopup.gameObject.SetActive(false);
    }

    public void DepositCash(int money)
    {
        if(int.Parse(Cash.text) < money)
        {
            PushLackPopup();
        }
        else
        {
            Cash.text = (int.Parse(Cash.text) - money).ToString();
            Account.text = (int.Parse(Account.text) +money).ToString();
        }
    }

    public void DepositCash()
    {
        if (int.Parse(Cash.text) < int.Parse(inputCash.text))
        {
            PushLackPopup();
        }
        else
        {
            Cash.text = (int.Parse(Cash.text) - int.Parse(inputCash.text)).ToString();
            Account.text = (int.Parse(Account.text) + int.Parse(inputCash.text)).ToString();
        }
    }
    
    public void WithdrawCash(int money)
    {
        if(int.Parse(Account.text) < money)
        {
            PushLackPopup();
        }
        else
        {
            Account.text = (int.Parse(Account.text) - money).ToString();
            Cash.text = (int.Parse(Cash.text) + money).ToString();
        }
    }

    public void WithdrawCash()
    {
        if (int.Parse(Account.text) < int.Parse(inputAccount.text))
        {
            PushLackPopup();
        }
        else
        {
            Account.text = (int.Parse(Account.text) - int.Parse(inputCash.text)).ToString();
            Cash.text = (int.Parse(Cash.text) + int.Parse(inputCash.text)).ToString();
        }
    }
}
