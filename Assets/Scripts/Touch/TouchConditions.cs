using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchConditions : MonoBehaviour
{
    [SerializeField]
     private TouchConditions touchConditions;

    private void OnEnable() 
    {
        EventManager.OnPlayGame.Invoke();
    }

    private void Awake() 
    {
        touchConditions = this.gameObject.GetComponent<TouchConditions>();

        EventManager.OnMainMenu.AddListener(DisableThisScript);
        EventManager.OnFailedTouch.AddListener(DisableThisScript);
        EventManager.OnPlayGame.AddListener(EnableThisScript);
    }

    public void EnableThisScript()
    {
       touchConditions.enabled = true; 
       //EventManager.OnPlayGame.Invoke();    
    }

    public void DisableThisScript()
    {
       touchConditions.enabled = false; 
    }

    private void Update()
    {
        TouchScreen();
    }

    public void TouchScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ExternalCircleScale.circleScaleX < GameplayParameters.maxScaleTollerance && ExternalCircleScale.circleScaleX > GameplayParameters.minScaleTollerance)
            {
                EventManager.OnGoodTouch.Invoke();
               // Debug.Log("Good");
            }

            if (ExternalCircleScale.circleScaleX >= GameplayParameters.perfectScaleMinimum && ExternalCircleScale.circleScaleX <= GameplayParameters.perfectScaleMaximum)
            {
                EventManager.OnPerfectTouch.Invoke();
                //Debug.Log("Perfect");
            }

            if (ExternalCircleScale.circleScaleX > GameplayParameters.maxScaleTollerance || ExternalCircleScale.circleScaleX < GameplayParameters.minScaleTollerance)
            {
                EventManager.OnFailedTouch.Invoke();
                //Debug.Log("Failed");
            }
        }

        if (ExternalCircleScale.circleScaleX < GameplayParameters.minScaleTollerance)
            {
                
               // Debug.Log("Failed");
            }
    }
}
