using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVersion : MonoBehaviour
{

    Version version = new Version();

    private const string versionKey = "version";

    private const string baseString = "0.0.7";

    public static bool isDifferentVersion = false;

    private void Start() 
    {
#if UNITY_ANDROID
       StartCoroutine(OnLoggedIn());
#endif
    }

    IEnumerator OnLoggedIn()
    {
        yield return new WaitUntil(() => PlayFabLogin.loginIsDone == true);
        GetVersion();
        //GetCircleProperties();
    }

   public void GetVersion()
    {
        var request = new GetTitleDataRequest { Keys = new List<string> { "Version" }};
        PlayFabClientAPI.GetTitleData(request, OnVersionResult, OnVersionError);
    }

    private void OnVersionResult(GetTitleDataResult obj)
    {
        Debug.Log("Getting Version");

        version = JsonUtility.FromJson<Version>(obj.Data["Version"]);

        CompareVersion();

        Debug.Log("Game Version : " + version.LiveVersion);
        
    }

    private void OnVersionError(PlayFabError obj)
    {
       Debug.Log("Could not get Version");
    }

    private void CompareVersion()
    {
        if(PlayerPrefs.HasKey(versionKey))
        {
            if(PlayerPrefs.GetString(versionKey) != version.LiveVersion)
            {
                EventManager.OnGameVersionChanged.Invoke();
                PlayerPrefs.SetString(versionKey, version.LiveVersion);
                isDifferentVersion = true;
            }
        }
        else
        {
            PlayerPrefs.SetString(versionKey, baseString);
        }
    }
}

[System.Serializable]
    public class Version
    {
        public string LiveVersion;
    }

