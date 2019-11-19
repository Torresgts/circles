using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour
{

    private bool shouldLerp = false;

    private float timeStartedLerping;
    public float lerpTime;

    public Vector2 startScale;
    public Vector2 endScale;

    private void OnEnable()
    {
        EventManager.OnStartGameplay.AddListener(SetLerpTime);
        EventManager.OnGoodTouch.AddListener(ReduceLerpTime);
    }

    private void OnDisable()
    {
        EventManager.OnStartGameplay.RemoveListener(SetLerpTime);
        EventManager.OnGoodTouch.RemoveListener(ReduceLerpTime);
    }

    void Start()
    {
       // StartLerping();
    }

    public void SetLerpTime()
    {
        lerpTime = GameplayParameters.initialTime;
       // Debug.Log(lerpTime);
    }

    public void ReduceLerpTime()
    {
        lerpTime -= GameplayParameters.timeReduceAmount;
        //Debug.Log("Lerp Time " + lerpTime);
    }

    public void StartLerping()
    {
            timeStartedLerping = Time.time;
            shouldLerp = true;
        
    }

    private void Update()
    {
        if (shouldLerp && GameplayParameters.gameplayStarted)
        {
            transform.localScale = Lerp(startScale, endScale, timeStartedLerping, lerpTime);
        }
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {

        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
