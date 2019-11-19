using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalCircleUI : MonoBehaviour
{
    public static LerpScale lerpScale;

    void Awake()
    {
        lerpScale = this.gameObject.GetComponent<LerpScale>();
    }
    private void OnEnable()
    {
        EventManager.OnGoodTouch.AddListener(ReduceCircleScaleLerp);
        EventManager.OnPerfectTouch.AddListener(ReduceCircleScaleLerp);
        EventManager.OnStartGameplay.AddListener(ReduceCircleScaleLerp);
    }
    private void OnDisable()
    {
        EventManager.OnGoodTouch.RemoveListener(ReduceCircleScaleLerp);
        EventManager.OnPerfectTouch.RemoveListener(ReduceCircleScaleLerp);
        EventManager.OnStartGameplay.RemoveListener(ReduceCircleScaleLerp);
        
    }

    private void Update()
    {
        ExternalCircleScale.circleScaleX = this.gameObject.transform.localScale.x;
        ExternalCircleTime.lerpTime = lerpScale.lerpTime;
    }

    private void ReduceCircleScaleLerp()
    {
        StartCoroutine(ReduceCircleLerp());        
    }

    IEnumerator ReduceCircleLerp()
    {
        yield return new WaitForEndOfFrame();
        lerpScale.StartLerping();
        lerpScale.endScale = Vector2.zero;

    }
}
