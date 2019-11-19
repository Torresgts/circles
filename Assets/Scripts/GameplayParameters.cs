using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayParameters : MonoBehaviour
{
    public static float initialTime, timeReduceAmount, minimumTime;
    public static float maxScaleTollerance, minScaleTollerance, perfectScaleMinimum, perfectScaleMaximum;

    public static bool gameplayStarted = false;

    [SerializeField]
    public CircleParametersListScriptableObjects circleParametersList;

    private void OnEnable()
    {
        EventManager.OnPlayGameButton.AddListener(SetGameplayTimeParameter);
        EventManager.OnPlayGameButton.AddListener(SetGameplayScaleParameters);
        EventManager.OnStartGameplay.AddListener(AllowGameplayToStart);
    }

    private void OnDisable()
    {
        EventManager.OnPlayGameButton.RemoveListener(SetGameplayTimeParameter);
        EventManager.OnPlayGameButton.RemoveListener(SetGameplayScaleParameters);
    }

    public void SetGameplayTimeParameter()
    {
        if (PlayFabLogin.loginIsDone && GameVersion.isDifferentVersion)
        {
            EventManager.OnGameDataUpdated.Invoke();
        }
        else if (PlayFabLogin.loginIsDone && !GameVersion.isDifferentVersion && PlayerPrefs.HasKey(PlayFabGetCircleParameters.initialTimeKey))
        {
            EventManager.OnGameDataNotUpdated.Invoke();
        }
        else
        {
            initialTime = circleParametersList.circleTimeParameters[0].initialTime;
            timeReduceAmount = circleParametersList.circleTimeParameters[0].timeReduceAmount;
            minimumTime = circleParametersList.circleTimeParameters[0].minimumTime;
        }


    }

    public void SetGameplayScaleParameters()
    {
        maxScaleTollerance = circleParametersList.circleScaleParameters[0].maxScaleTollerance;
        minScaleTollerance = circleParametersList.circleScaleParameters[0].minScaleTollerance;
        perfectScaleMinimum = circleParametersList.circleScaleParameters[0].perfectScaleMinimum;
        perfectScaleMaximum = circleParametersList.circleScaleParameters[0].perfectScaleMaximum;

        //Debug.Log(maxScaleTollerance + " " + minScaleTollerance + " " + perfectScaleMinimum + " " + perfectScaleMaximum);
    }

    public void AllowGameplayToStart()
    {
        StartCoroutine(WaitAndAllowGameplayToStart());
        //gameplayStarted = true;
    }

    IEnumerator WaitAndAllowGameplayToStart()
    {
        yield return new WaitForSeconds(1);
        gameplayStarted = true;
    }
}
