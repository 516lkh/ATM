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
}
