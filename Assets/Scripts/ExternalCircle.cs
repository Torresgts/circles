using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalCircle : MonoBehaviour
{
    float time = 3.5f;
    
        void Start()
    {
        ReduceCircleScale();
     
    }

    void Update()
    {
        InputConditions();
        ResizeCircleScale();
        
    }

    private void ReduceCircleScale(){
        iTween.ScaleTo(this.gameObject, new Vector3(0,0,0), time);
    }

    private void ResizeCircleScale()
    {
        if(this.gameObject.transform.localScale.x <= 0f){
            this.gameObject.transform.localScale = new Vector3(1,1,0);
            time = time - 0.045f;
            ReduceCircleScale();
        }
        
    }

    private void InputConditions(){
        if(Input.GetMouseButtonDown(0)){
            if(this.gameObject.transform.localScale.x < 0.17f){
                ScoreHandler.score++;
                Debug.Log("YEY");
            }

            if(this.gameObject.transform.localScale.x > 0.17f){
                Debug.Log("NOOO");
            }
        }
    }

    
}
