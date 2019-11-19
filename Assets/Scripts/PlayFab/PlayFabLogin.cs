using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayFabLogin : MonoBehaviour
{

    public static bool loginIsDone = false;

    
    public void Start()
    {
        // Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId)){
            PlayFabSettings.staticSettings.TitleId = "5C525"; // Please change this value to your own titleId from PlayFab Game Manager
        }

#if UNITY_ANDROID
       LoginOnAndroid();
#endif
    }

#region Login

    private void LoginOnAndroid()
    {
        var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID(),  CreateAccount = true };
        PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginAndroidSuccess, OnLoginAndroidFailure);
    }
    private void OnLoginAndroidSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, Android Logged in");
        loginIsDone = true;
    }

    private void OnLoginAndroidFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    public static string ReturnMobileID()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        return deviceID;
    }
#endregion

}