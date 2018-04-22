using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demo : MonoBehaviour
{
    public Button GetTimeBtn;
    public Button ShowToastBtn;
    public Text ShowTimeTxt;
    public InputField ToastIpt;

    AndroidJavaObject ajo;

    private void Awake()
    {
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
    }

    void Start()
    {
        GetTimeBtn.onClick.AddListener(OnGetTimeBtnClick);
        ShowToastBtn.onClick.AddListener(OnShowToastBtnClick);
        ToastIpt.onEndEdit.AddListener(OnToastIptEndEdit);
    }

    private void OnToastIptEndEdit(string arg0)
    {
        Debug.Log("111");
    }

    private void OnShowToastBtnClick()
    {
        ajo.Call("showToast",ToastIpt.text,1);
    }

    private void OnGetTimeBtnClick()
    {
        string callback = ajo.Call<string>("getNowTime");
        ShowTimeTxt.text = callback;
    }

}
