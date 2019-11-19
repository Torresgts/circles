using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabGetCircleParameters : MonoBehaviour
{
    CircleProperties circleProperties = new CircleProperties();


    private void OnEnable() 
    {
        EventManager.OnGameVersionChanged.AddListener(GetCircleProperties);
        EventManager.OnGameDataUpdated.AddListener(ChangeCircleTimeParameters);

        EventManager.OnGameDataNotUpdated.AddListener(GetCircleParametersPlayerPrefs);
    }

    private void OnDisable()
    {
        EventManager.OnGameVersionChanged.RemoveListener(GetCircleProperties);
        EventManager.OnGameDataUpdated.RemoveListener(ChangeCircleTimeParameters);

        EventManager.OnGameDataNotUpdated.RemoveListener(GetCircleParametersPlayerPrefs);
    }


    void Start()
    {
#if UNITY_ANDROID
       //StartCoroutine(OnLoggedIn());
#endif
    }


    public void GetCircleProperties()
    {
        var request = new GetTitleDataRequest { Keys = new List<string> { "CircleParameters" }};
        PlayFabClientAPI.GetTitleData(request, OnCircleParametersResult, OnCircleParametersError);
    }

    private void OnCircleParametersResult(GetTitleDataResult obj)
    {
        Debug.Log("Getting Circle Parameters");

        circleProperties = JsonUtility.FromJson<CircleProperties>(obj.Data["CircleParameters"]);

        SetCircleParametersPlayerPrefs();
        //Debug.Log("circleProperties Time : " + circleProperties.InitialTime + " " + circleProperties.MinimumTime +" " + circleProperties.TimeReduceAmount);
        //Debug.Log("circleProperties Scale : " + circleProperties.MaxScaleTollerance + " " + circleProperties.MinScaleTollerance +" " + circleProperties.PerfectScaleMaximum + " " + circleProperties.PerfectScaleMinimum);
    }

    private void OnCircleParametersError(PlayFabError obj)
    {
       Debug.Log("Could not get Circle Parameters");
    }

    public void ChangeCircleTimeParameters()
    {
        GameplayParameters.initialTime = circleProperties.InitialTime;
        GameplayParameters.timeReduceAmount = circleProperties.TimeReduceAmount;
        GameplayParameters.minimumTime = circleProperties.MinimumTime;

        GameplayParameters.maxScaleTollerance = circleProperties.MaxScaleTollerance;
        GameplayParameters.minScaleTollerance = circleProperties.MinScaleTollerance;
        GameplayParameters.perfectScaleMinimum = circleProperties.PerfectScaleMinimum;
        GameplayParameters.perfectScaleMaximum = circleProperties.PerfectScaleMaximum;
        
    }

    public const string initialTimeKey = "InitialTime";
    private const string timeRedouceAmountKey = "TimeReduceAmount";
    private const string minimumTimeKey = "MinimumTime";
    private const string maxScaleTolleranceKey = "MaxScaleTollerance";
    private const string minScaleTolleranceKey = "MinScaleTollerance";
    private const string perfectScaleMinimumKey = "PerfectScaleMinimum";
    private const string perfectScaleMaximumKey = "PerfectScaleMaximum";


   /* public void SetCircleParametersPlayerPrefsFirstOpenning()
    {
        PlayerPrefs.SetFloat(initialTimeKey, circleProperties.InitialTime);
        PlayerPrefs.SetFloat(timeRedouceAmountKey, circleProperties.TimeReduceAmount);
        PlayerPrefs.SetFloat(minimumTimeKey, circleProperties.MinimumTime);
        PlayerPrefs.SetFloat(maxScaleTolleranceKey, circleProperties.MaxScaleTollerance);
        PlayerPrefs.SetFloat(minScaleTolleranceKey, circleProperties.MinScaleTollerance);
        PlayerPrefs.SetFloat(perfectScaleMinimumKey, circleProperties.PerfectScaleMinimum);
        PlayerPrefs.SetFloat(perfectScaleMaximumKey, circleProperties.PerfectScaleMaximum);
    }*/
    public void SetCircleParametersPlayerPrefs()
    {
        PlayerPrefs.SetFloat(initialTimeKey, circleProperties.InitialTime);
        PlayerPrefs.SetFloat(timeRedouceAmountKey, circleProperties.TimeReduceAmount);
        PlayerPrefs.SetFloat(minimumTimeKey, circleProperties.MinimumTime);
        PlayerPrefs.SetFloat(maxScaleTolleranceKey, circleProperties.MaxScaleTollerance);
        PlayerPrefs.SetFloat(minScaleTolleranceKey, circleProperties.MinScaleTollerance);
        PlayerPrefs.SetFloat(perfectScaleMinimumKey, circleProperties.PerfectScaleMinimum);
        PlayerPrefs.SetFloat(perfectScaleMaximumKey, circleProperties.PerfectScaleMaximum);
    }

     public void GetCircleParametersPlayerPrefs()
    {
        GameplayParameters.initialTime = PlayerPrefs.GetFloat(initialTimeKey);
        GameplayParameters.timeReduceAmount = PlayerPrefs.GetFloat(timeRedouceAmountKey);
        GameplayParameters.minimumTime = PlayerPrefs.GetFloat(minimumTimeKey);

        GameplayParameters.maxScaleTollerance = PlayerPrefs.GetFloat(maxScaleTolleranceKey);
        GameplayParameters.minScaleTollerance = PlayerPrefs.GetFloat(minScaleTolleranceKey);
        GameplayParameters.perfectScaleMinimum = PlayerPrefs.GetFloat(perfectScaleMinimumKey);
        GameplayParameters.perfectScaleMaximum = PlayerPrefs.GetFloat(perfectScaleMaximumKey);
    }

    

    
}


[System.Serializable]
    public class CircleProperties
    {
        public float InitialTime;
        public float TimeReduceAmount;
        public float MinimumTime;

        public float MaxScaleTollerance;
        public float MinScaleTollerance;
        public float PerfectScaleMinimum;
        public float PerfectScaleMaximum;

    }
