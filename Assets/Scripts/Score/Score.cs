using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static int score = 0;
    
    void Awake()
    {
      EventManager.IncrementScore.AddListener(IncrementScore);
      EventManager.IncrementBonusScore.AddListener(IncrementBonusScore);
    }

    public void IncrementScore(){
        if(Input.GetMouseButtonDown(0)){
           score++;
        }   
    }

    public void IncrementBonusScore(){
        if(Input.GetMouseButtonDown(0)){
           score++;
        }   
    }
    
}
