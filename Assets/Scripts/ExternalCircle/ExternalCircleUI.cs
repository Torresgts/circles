using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalCircleUI : MonoBehaviour
{
    public static LerpScale lerpScale;


     void Awake()
    {
        EventManager.ReduceCircleScaleLerp.AddListener(ReduceCircleScaleLerp);

        lerpScale = this.gameObject.GetComponent<LerpScale>();
    }

    private void Update() {
        ExternalCircleScale.circleScaleX = this.gameObject.transform.localScale.x;
        ExternalCircleTime.lerpTime =  lerpScale.lerpTime;
    }

     private void ReduceCircleScaleLerp(){
        lerpScale.StartLerping();
        lerpScale.endScale = Vector2.zero;
    }
}
