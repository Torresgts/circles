using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOutcome : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Started");
    }

    private void Awake() {
        EventManager.IncrementScore.AddListener(GoodTouch);
        EventManager.IncrementScore.AddListener(PerfectTouch);
        EventManager.IncrementScore.AddListener(FailedTouch);
    }

   public void GoodTouch(){
       EventManager.IncrementScore.Invoke();
       EventManager.IncrementScoreText.Invoke();
       EventManager.ReduceCircleScaleLerp.Invoke();
       Debug.Log("Good");
   }

   public void PerfectTouch(){
       EventManager.IncrementBonusScore.Invoke();
       EventManager.IncrementScoreText.Invoke();
       EventManager.ReduceCircleScaleLerp.Invoke();
   }

   public void FailedTouch(){
        Debug.Log("Failed");
   }
}
