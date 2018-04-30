using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class demo2 : MonoBehaviour
{
    public Button GetTimeBtn;
    public Button ShowToastBtn;
    public Text ShowTimeTxt;
    public Text ShowTimeTxt2;
    public Text ShowTimeTxt3;
    public Button BackSceneBtn;
    public InputField ToastIpt;

    private void Awake()
    {
#if UNITY_EDITOR

#elif UNITY_ANDROID
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
#endif
    }

    void Start()
    {
        GetTimeBtn.onClick.AddListener(OnGetTimeBtnClick);
        ShowToastBtn.onClick.AddListener(OnShowToastBtnClick);
        ToastIpt.onEndEdit.AddListener(OnToastIptEndEdit);
        BackSceneBtn.onClick.AddListener(OnBackSceneBtnClick);
    }

    private void OnBackSceneBtnClick()
    {
        Debug.Log("JumpBack");
        SceneManager.LoadScene(0);
    }

    private void OnToastIptEndEdit(string arg0)
    {

    }


    /// <summary>
    /// androidJavaProxy测试
    /// </summary>
    private void OnShowToastBtnClick()
    {
        Debug.Log("调用AJP-吃饭-睡觉-打豆豆");
        AndroidJavaObject ajc = new AndroidJavaObject("com.han.tools.ajcTest");
        AndroidJavaProxyTest ajp = new AndroidJavaProxyTest("com.han.tools.IJavaProxy", ShowTimeTxt, ShowTimeTxt2, ShowTimeTxt3);

        ajc.Call("PeoPleDoSomething", ajp);
    }


    private void OnGetTimeBtnClick()
    {
        Debug.Log("调用Runable-RunableTest");
        AndroidJavaObject ajc = new AndroidJavaObject("com.han.tools.ajcTest");
        ajc.Call("RunableTest", new AndroidJavaRunnable(Runable));
    }


    private void Runable()
    {
        ShowTimeTxt.text = "RunableTest";
    }


    class AndroidJavaProxyTest : AndroidJavaProxy
    {
        public Text txt1;
        public Text txt2;
        public Text txt3;

        public AndroidJavaProxyTest(string packageName, Text t1, Text t2, Text t3) : base(packageName)
        {
            this.txt1 = t1;
            this.txt2 = t2;
            this.txt3 = t3;
        }

        public void Eat()
        {
            txt1.text = "吃饭";
        }

        public void Sleep()
        {
            txt2.text = "睡觉";
        }

        public void Code()
        {
            txt3.text = "打豆豆";
        }
    }

}
