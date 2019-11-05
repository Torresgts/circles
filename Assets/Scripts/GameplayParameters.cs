using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayParameters : MonoBehaviour
{
    
    public static float initialTime, timeReduceAmount, minimumTime;
    public static float maxScaleTollerance, minScaleTollerance;

    [SerializeField]
    public CircleParametersListScriptableObjects circleParametersList;

    private void Awake() {
        EventManager.SetGameplayTimeParameter.AddListener(SetGameplayTimeParameter);
        EventManager.SetGameplayScaleParameters.AddListener(SetGameplayScaleParameters);
    }

    public void SetGameplayTimeParameter(){
        initialTime = circleParametersList.circleTimeParameters[0].initialTime;
        timeReduceAmount = circleParametersList.circleTimeParameters[0].timeReduceAmount;
        minimumTime =  circleParametersList.circleTimeParameters[0].minimumTime;
    }

    public void SetGameplayScaleParameters(){
        maxScaleTollerance = circleParametersList.circleScaleParameters[0].maxScaleTollerance;
        minScaleTollerance = circleParametersList.circleScaleParameters[0].minScaleTollerance;
    }
}
