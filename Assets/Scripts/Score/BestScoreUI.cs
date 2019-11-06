using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreUI : MonoBehaviour
{
    [SerializeField]
     private TMP_Text gameOverScoreText;
    [SerializeField]
    private TMP_Text bestScoreText;

    private void OnEnable() 
    {
        EventManager.OnFailedTouch.AddListener(IncrementGameOverScoreAndBestScoreUI);    
    }

      public void IncrementGameOverScoreAndBestScoreUI()
      {
          gameOverScoreText.text = Score.score.ToString();
          bestScoreText.text = Score.bestScore.ToString();
      } 

}
