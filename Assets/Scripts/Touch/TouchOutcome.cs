using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOutcome : MonoBehaviour
{
    private void OnEnable()
    {
       /*  EventManager.GoodTouch.AddListener(GoodTouch);
        EventManager.PerfectTouch.AddListener(PerfectTouch);
        EventManager.FailedTouch.AddListener(FailedTouch);*/
    }

    private void OnDisable()
    {
       /*  EventManager.GoodTouch.RemoveListener(GoodTouch);
        EventManager.PerfectTouch.RemoveListener(PerfectTouch);
        EventManager.FailedTouch.RemoveListener(FailedTouch);*/
    }

    public void GoodTouch()
    {

        Debug.Log("Good");
    }

    public void PerfectTouch()
    {
       /* EventManager.IncrementBonusScore.Invoke();
        EventManager.IncrementScoreText.Invoke();
        EventManager.ReduceCircleScaleLerp.Invoke();*/
    }

    public void FailedTouch()
    {
        Debug.Log("Failed");
    }

}
