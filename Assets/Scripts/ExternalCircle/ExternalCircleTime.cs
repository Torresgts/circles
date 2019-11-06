using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalCircleTime : MonoBehaviour
{
    public static float lerpTime;

    private void ReduceTime()
    {
        if (ExternalCircleTime.lerpTime > GameplayParameters.minimumTime)
        {
            ExternalCircleTime.lerpTime -= GameplayParameters.timeReduceAmount;
        }
    }
}
