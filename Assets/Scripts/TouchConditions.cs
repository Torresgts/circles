using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchConditions : MonoBehaviour
{

   private void Update() {
      
       if(Input.GetMouseButtonDown(0)){

        if(ExternalCircleScale.circleScaleX < GameplayParameters.maxScaleTollerance && ExternalCircleScale.circleScaleX > GameplayParameters.minScaleTollerance){
            EventManager.GoodTouch.Invoke();
            Debug.Log("Good");
        }

        if(ExternalCircleScale.circleScaleX > GameplayParameters.maxScaleTollerance || ExternalCircleScale.circleScaleX <  GameplayParameters.minScaleTollerance){
            EventManager.FailedTouch.Invoke();
        }
       }
   }
}
