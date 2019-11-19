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
        EventManager.OnUpdateUI.AddListener(IncrementGameOverScoreAndBestScoreUI); 
    }

    private void OnDisable()
    {
         EventManager.OnFailedTouch.RemoveListener(IncrementGameOverScoreAndBestScoreUI);
    }

      public void IncrementGameOverScoreAndBestScoreUI()
      {
          gameOverScoreText.text = Score.score.ToString();
          bestScoreText.text = Score.bestScore.ToString();
      } 

}
