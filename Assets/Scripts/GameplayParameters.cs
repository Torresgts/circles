using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayParameters : MonoBehaviour
{
    public static float initialTime, timeReduceAmount, minimumTime;
    public static float maxScaleTollerance, minScaleTollerance, perfectScaleMinimum, perfectScaleMaximum;

    [SerializeField]
    public CircleParametersListScriptableObjects circleParametersList;

    private void OnEnable()
    {
        EventManager.OnPlayGame.AddListener(SetGameplayTimeParameter);
        EventManager.OnPlayGame.AddListener(SetGameplayScaleParameters);
    }

    private void OnDisable()
    {
        EventManager.OnPlayGame.RemoveListener(SetGameplayTimeParameter);
        EventManager.OnPlayGame.RemoveListener(SetGameplayScaleParameters);
    }

    public void SetGameplayTimeParameter()
    {
        if (PlayFabLogin.loginIsDone)
        {
            EventManager.OnGameDataUpdated.Invoke();
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
    }
}
