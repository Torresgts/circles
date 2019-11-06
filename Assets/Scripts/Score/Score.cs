using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;

     private void OnEnable()
    {
        EventManager.OnGoodTouch.AddListener(IncrementScore);
        EventManager.OnPerfectTouch.AddListener(IncrementBonusScore);
        EventManager.OnPlayGame.AddListener(ZeroScore);
        
    }

    private void OnDisable() {
        EventManager.OnGoodTouch.RemoveListener(IncrementScore);
        EventManager.OnPerfectTouch.RemoveListener(IncrementBonusScore);
        EventManager.OnPlayGame.RemoveListener(ZeroScore);
    }

    public void IncrementScore(){
        score++;
        
        /*if(Input.GetMouseButtonDown(0)){
           
        }   */
    }

    public void IncrementBonusScore(){
        score = score + 3;

       /* if(Input.GetMouseButtonDown(0)){
           score++;
        }   */
    }

    public void ZeroScore()
    {
        score = 0;
    }
    
}
