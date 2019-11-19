using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchConditions : MonoBehaviour
{
    [SerializeField]
     private TouchConditions touchConditions;

    private void OnEnable() 
    {
        //EventManager.OnPlayGame.Invoke();

        EventManager.OnStartGameplay.Invoke();

    }

    private void Awake() 
    {
        touchConditions = this.gameObject.GetComponent<TouchConditions>();

        EventManager.OnMainMenu.AddListener(DisableThisScript);
        EventManager.OnFailedTouch.AddListener(DisableThisScript);
        EventManager.OnPlayGameButton.AddListener(EnableThisScript);
    }

    public void EnableThisScript()
    {
       touchConditions.enabled = true; 
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
        if (Input.GetMouseButtonDown(0) && GameplayParameters.gameplayStarted)
        {
            if (ExternalCircleScale.circleScaleX <= GameplayParameters.maxScaleTollerance && ExternalCircleScale.circleScaleX >= GameplayParameters.minScaleTollerance)
            {
                EventManager.OnGoodTouch.Invoke();
                EventManager.OnPlaySound.Invoke("GoodTouch");
                //Debug.Log("Good 1 Point");
            }
            if (ExternalCircleScale.circleScaleX >= GameplayParameters.perfectScaleMinimum && ExternalCircleScale.circleScaleX <= GameplayParameters.perfectScaleMaximum)
            {
                EventManager.OnPerfectTouch.Invoke();
                EventManager.OnPlaySound.Invoke("PerfectTouch");
                //Debug.Log("Perfect 3 Points");
            }
           if (ExternalCircleScale.circleScaleX > GameplayParameters.maxScaleTollerance || ExternalCircleScale.circleScaleX < GameplayParameters.perfectScaleMinimum)
            {
                EventManager.OnFailedTouch.Invoke();
                EventManager.OnPlaySound.Invoke("FailedTouch");
                GameplayParameters.gameplayStarted = false;
                //Debug.Log("Failed");
            }
        }

        if (ExternalCircleScale.circleScaleX < GameplayParameters.perfectScaleMinimum)
            {
                if(GameplayParameters.gameplayStarted)
                {
                    EventManager.OnFailedTouch.Invoke();
                    EventManager.OnPlaySound.Invoke("FailedTouch");
                    GameplayParameters.gameplayStarted = false;
                }
                
            }
    }
}
