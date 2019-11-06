using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleScaleParameters", menuName = "ScriptableObjects/CircleScaleParameters", order = 1)]
public class CircleScaleParametersScriptableObject : ScriptableObject
{
    public float maxScaleTollerance;

    public float minScaleTollerance;

    public float perfectScaleMinimum;
    public float perfectScaleMaximum;
}
