using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class demo1 : MonoBehaviour
{
    public Button GetTimeBtn;
    public Button ShowToastBtn;
    public Text ShowTimeTxt;
    public InputField ToastIpt;
    public Button JumpScene;
    public Button QuitBtn;

    AndroidJavaObject ajo;

    private void Awake()
    {
#if UNITY_EDITOR

#elif UNITY_ANDROID
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
#endif
    }

    void Start()
    {
        GetTimeBtn.onClick.AddListener(OnGetTimeBtnClick);
        ShowToastBtn.onClick.AddListener(OnShowToastBtnClick);
        ToastIpt.onEndEdit.AddListener(OnToastIptEndEdit);
        JumpScene.onClick.AddListener(OnJumpSceneBtnClick);
        QuitBtn.onClick.AddListener(OnQuitBtnClick);
    }

    private void OnQuitBtnClick()
    {
        Application.Quit();
    }

    private void OnJumpSceneBtnClick()
    {
        Debug.Log("Jump");
        SceneManager.LoadScene(1);
    }

    private void OnToastIptEndEdit(string arg0)
    {
        Debug.Log("111");
    }

    private void OnShowToastBtnClick()
    {
        ajo.Call("showToast",ToastIpt.text,1);
        CallAJCTest();
    }

    private void OnGetTimeBtnClick()
    {

        string callback = ajo.Call<string>("getNowTime");
        ShowTimeTxt.text = callback;
    }


    private void CallAJCTest()
    {
        AndroidJavaObject ajoajo = new AndroidJavaObject("com.han.tools.ajcTest");
        string s = ajoajo.Call<string>("getNowTime");
        ShowTimeTxt.text = s;
    }

}
