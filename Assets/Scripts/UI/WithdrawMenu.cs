using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WithdrawMenu : View
{
    [SerializeField] private Button _backBtn;
    [SerializeField] private Button _option1;
    [SerializeField] private Button _option2;
    [SerializeField] private Button _option3;
    [SerializeField] private Button _option4;
    [SerializeField] private TMP_InputField inputFigure;

    public override void Initialize()
    {
        _backBtn.onClick.AddListener(() => UIManager.ShowLast());
        _option1.GetComponentInChildren<TMP_Text>().text = string.Format("{0:N0}", BankingManager.Instance.atm.so_ATM.option1);
        _option2.GetComponentInChildren<TMP_Text>().text = string.Format("{0:N0}", BankingManager.Instance.atm.so_ATM.option2);
        _option3.GetComponentInChildren<TMP_Text>().text = string.Format("{0:N0}", BankingManager.Instance.atm.so_ATM.option3);
        _option1.onClick.AddListener(() => BankingManager.Instance.Withdraw(BankingManager.Instance.atm.so_ATM.option1));
        _option2.onClick.AddListener(() => BankingManager.Instance.Withdraw(BankingManager.Instance.atm.so_ATM.option2));
        _option3.onClick.AddListener(() => BankingManager.Instance.Withdraw(BankingManager.Instance.atm.so_ATM.option3));
        _option4.onClick.AddListener(() =>{ BankingManager.Instance.Withdraw(int.Parse(inputFigure.text)); inputFigure.text = ""; });
    }
}
