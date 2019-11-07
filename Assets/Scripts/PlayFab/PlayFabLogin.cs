using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using PlayFab.Json;

public class PlayFabLogin : MonoBehaviour
{
    //private string userEmail;
    //private string userPassword;
    
    //public static bool hasLoggedIn = false;
    private float initialTime;

    private CircleProperties circleProperties;


    public static bool loginIsDone = false;

    private JSONObject circleParams;

    private void OnEnable() 
    {
        EventManager.OnGameDataUpdated.AddListener(ChangeCircleTimeParameters);
    }

    private void OnDisable()
    {
        EventManager.OnGameDataUpdated.RemoveListener(ChangeCircleTimeParameters);
    }

    public void Start()
    {
        // Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId)){
            PlayFabSettings.staticSettings.TitleId = "5C525"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true};
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

        //var request = new LoginWithEmailAddressRequest {Email = userEmail, Password = userPassword};
        //PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    #if UNITY_ANDROID
        var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID(),  CreateAccount = true };
        PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginAndroidSuccess, OnLoginAndroidFailure);
    #endif

    #if UNITY_IOS
        
    #endif

    StartCoroutine(GetDataTest());

    }

#region Login
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

/*  public void GetNameTitleData() {
        PlayFabClientAPI.GetTitleData(
            new GetTitleDataRequest(),
            
            result => {
                if(result.Data == null || !result.Data.ContainsKey("CircleParameters")) 
                {
                    Debug.Log("No CircleParameters was found");
                }
                else{
                    Debug.Log("Parameters: " + result.Data["CircleParameters"]);
                    circleProperties = jso
                } 
            },
            
            error => {
                Debug.Log("Got error getting titleData:");
                Debug.Log(error.GenerateErrorReport());
            }
        );
    }*/


    public void GetCircleProperties()
    {
        var request = new GetTitleDataRequest { Keys = new List<string> { "CircleParameters" }};
        PlayFabClientAPI.GetTitleData(request, OnCircleParametersResult, OnCircleParametersError);
    }

    private void OnCircleParametersResult(GetTitleDataResult obj)
    {
        Debug.Log("Getting Circle Parameters");
        //Debug.Log(obj.Data["CircleParameters"]);

        circleParams = (JSONObject)JSON.Parse(obj.Data["CircleParameters"]);

        
        Debug.Log(initialTime);
        
    }

    private void OnCircleParametersError(PlayFabError obj)
    {
       Debug.Log("Could not get Circle Parameters");
    }

    public void ChangeCircleTimeParameters()
    {
        GameplayParameters.initialTime = circleParams["InitialTime"];
        GameplayParameters.timeReduceAmount = circleParams["TimeReduceAmount"];
        GameplayParameters.minimumTime = circleParams["MinimumTime"];

    }

    IEnumerator GetDataTest()
    {
        yield return new WaitUntil(() => loginIsDone == true);
        GetCircleProperties();
    }
}

[System.Serializable]
public class CircleProperties
{
    public string initialTime;
    public string timeReduceAmout;
    public string minimumTime;
}