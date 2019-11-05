using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExternalCircle : MonoBehaviour
{
    private float time = 3.5f;
    private const float timeToReduce = 0.095f;

    private const float maxScaleTollerance = 0.12f;
    private const float minScaleTollerance= 0.05f;

    LerpScale lerpScale;
    
    void Awake()
    {
        lerpScale = this.gameObject.GetComponent<LerpScale>();
    }

        void Start()
    {
        ReduceCircleScale();
     
    }

    void Update()
    {
        InputConditions();
        ChangeColorConditions();

       
    }

    private void ReduceCircleScale(){
        lerpScale.StartLerping();
        
        lerpScale.endScale = Vector2.zero;
    }


    private void ReduceTime(){
        if(lerpScale.lerpTime > 0.90f)
        {
            lerpScale.lerpTime -= timeToReduce;
        }
        
    }

    private void GainScore(){
       // ScoreHandler.score++;
    }

    private void InputConditions(){
        if(Input.GetMouseButtonDown(0)){
            if(this.gameObject.transform.localScale.x < maxScaleTollerance && this.gameObject.transform.localScale.x > minScaleTollerance){
                GainScore();
                ReduceCircleScale();
                ReduceTime();
                lerpScale.endScale = this.gameObject.transform.localScale;
                StartCoroutine(RedefineEndScale());
                Debug.Log("YEY");
            }

            if(this.gameObject.transform.localScale.x > maxScaleTollerance || this.gameObject.transform.localScale.x <  minScaleTollerance){
                Debug.Log("NOOO");

                ReduceCircleScale();
            }
        }
    }

    private void ChangeColor(Vector4 color)
    {
        this.gameObject.GetComponent<Image>().color = color;
    }

    private void ChangeColorConditions()
    {
        if((this.gameObject.transform.localScale.x <= maxScaleTollerance)){
            ChangeColor(new Vector4(0,0,0,1));
        }
        else{
            ChangeColor(new Vector4(255,255,255,1));
        }
    }

    IEnumerator RedefineEndScale()
    {
        //yield return new WaitForSeconds(0.01f);
        yield return new WaitForEndOfFrame();
        lerpScale.endScale = Vector2.zero;
    }
    
}
