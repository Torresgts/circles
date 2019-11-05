using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleTimeParameters", menuName = "ScriptableObjects/CircleTimeParameters", order = 1)]
public class CircleTimeParametersScriptableObject : ScriptableObject
{
 
    public float initialTime;

    public float timeReduceAmount;

    public float minimumTime;
}
