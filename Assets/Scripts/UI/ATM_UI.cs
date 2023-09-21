using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATM_UI : View
{

    public override void Initialize()
    {

    }

    public void OnEnable()
    {
        UIManager.ShowOverride<OptionMenu>();
    }

}
