using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : View
{
    [SerializeField] private Button _depositBtn;
    [SerializeField] private Button _withdrawBtn;

    public override void Initialize()
    {
        _depositBtn.onClick.AddListener(() => UIManager.Show<DepositMenu>());
        _withdrawBtn.onClick.AddListener(() => UIManager.Show<WithdrawMenu>());
    }

}
