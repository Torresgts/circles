using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleParametersList", menuName = "ScriptableObjects/CircleScaleParametersList", order = 1)]
public class CircleParametersListScriptableObjects : ScriptableObject
{
    public int index;
    public CircleScaleParametersScriptableObject[] circleScaleParameters;

    public CircleTimeParametersScriptableObject[] circleTimeParameters;
}
