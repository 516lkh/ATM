using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager UI_instance;

    [SerializeField] private View _startView;
    [SerializeField] private View[] _views;

    private View _currentView;
    private readonly Stack<View> _history = new Stack<View>();

    public static T GetVeiw<T>() where T : View
    {
        for (int i = 0; i < UI_instance._views.Length; i++)
        {
            if (UI_instance._views[i] is T tView)
            {
                return tView;
            }
        }

        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < UI_instance._views.Length; i++)
        {
            if (UI_instance._views[i] is T)
            {
                if (UI_instance._currentView != null)
                {
                    if (remember)
                    {
                        UI_instance._history.Push(UI_instance._currentView);
                    }

                    UI_instance._currentView.Hide();

                }
                UI_instance._currentView = UI_instance._views[i];

                UI_instance._views[i].Show();
            }
        }
    }

    public static void Show(View view, bool remember = true)
    {
        if( UI_instance._currentView != null)
        {
            if (remember)
            {
                UI_instance._history.Push(UI_instance._currentView);
            }
            UI_instance._currentView.Hide();
        }

        UI_instance._currentView = view;

        view.Show();
    }

    public static void ShowOverride<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < UI_instance._views.Length; i++)
        {
            if (UI_instance._views[i] is T)
            {
                if (UI_instance._currentView != null)
                {
                    if (remember)
                    {
                        UI_instance._history.Push(UI_instance._currentView);
                    }
                }
                UI_instance._currentView = UI_instance._views[i];

                UI_instance._views[i].Show();
            }
        }
    }


    public static void ShowLast()
    {
        if(UI_instance._history.Count != 0)
        {
            Show(UI_instance._history.Pop(), false);
        }
    }

    private void Awake()
    {
        UI_instance = this;
        //Cash = CashFigure.GetComponent<TMP_Text>();
        //Account = AccountFigure.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        for(int i=0; i < _views.Length; i++)
        {
            _views[i].Initialize();

            _views[i].Hide();
        }

        if(_startView != null)
        {
            Show(_startView, false);
        }
    }











    //public GameObject CashFigure;
    //public GameObject AccountFigure;
    //public GameObject Option;
    //public GameObject WithDraw;
    //public GameObject Deposit;
    //public GameObject LackPopup;

    //private TMP_Text Cash;
    //private TMP_Text Account;

    //public TMP_InputField inputCash;
    //public TMP_InputField inputAccount;

    //public void PushWithDraw()
    //{
    //    Option.gameObject.SetActive(false);
    //    WithDraw.gameObject.SetActive(true);
    //}

    //public void PushDeposit()
    //{
    //    Option.gameObject.SetActive(false);
    //    Deposit.gameObject.SetActive(true);
    //}

    //public void PushOption()
    //{
    //    WithDraw.gameObject.SetActive(false);
    //    Deposit.gameObject.SetActive(false);
    //    Option.gameObject.SetActive(true);
    //}

    //public void PushLackPopup()
    //{
    //    LackPopup.gameObject.SetActive(true);
    //}

    //public void PopLackPopup()
    //{
    //    LackPopup.gameObject.SetActive(false);
    //}

    //public void DepositCash(int money)
    //{
    //    if(int.Parse(Cash.text) < money)
    //    {
    //        PushLackPopup();
    //    }
    //    else
    //    {
    //        Cash.text = (int.Parse(Cash.text) - money).ToString();
    //        Account.text = (int.Parse(Account.text) +money).ToString();
    //    }
    //}

    //public void DepositCash()
    //{
    //    if (inputCash.text == "") return;

    //    if (int.Parse(Cash.text) < int.Parse(inputCash.text))
    //    {
    //        PushLackPopup();
    //    }
    //    else
    //    {
    //        Cash.text = (int.Parse(Cash.text) - int.Parse(inputCash.text)).ToString();
    //        Account.text = (int.Parse(Account.text) + int.Parse(inputCash.text)).ToString();
    //    }
    //    inputCash.text = "";
    //}
    
    //public void WithdrawCash(int money)
    //{
    //    if(int.Parse(Account.text) < money)
    //    {
    //        PushLackPopup();
    //    }
    //    else
    //    {
    //        Account.text = (int.Parse(Account.text) - money).ToString();
    //        Cash.text = (int.Parse(Cash.text) + money).ToString();
    //    }
    //}

    //public void WithdrawCash()
    //{
    //    if (inputAccount.text == "") return;

    //    if (int.Parse(Account.text) < int.Parse(inputAccount.text))
    //    {
    //        PushLackPopup();
    //    }
    //    else
    //    {
    //        Account.text = (int.Parse(Account.text) - int.Parse(inputAccount.text)).ToString();
    //        Cash.text = (int.Parse(Cash.text) + int.Parse(inputAccount.text)).ToString();
    //    }
    //    inputAccount.text = "";
    //}
}
