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
        EventManager.OnPlayGame.AddListener(ReduceCircleScaleLerp);
    }
    private void OnDisable()
    {
        EventManager.OnGoodTouch.RemoveListener(ReduceCircleScaleLerp);
        EventManager.OnPerfectTouch.RemoveListener(ReduceCircleScaleLerp);
        EventManager.OnPlayGame.RemoveListener(ReduceCircleScaleLerp);
        
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
        yield return new WaitForSeconds(0.2f);
        lerpScale.StartLerping();
        lerpScale.endScale = Vector2.zero;

    }
}
