using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int bestScore;


    private const string bestScoreKey = "bestscore";

     private void OnEnable()
    {
        EventManager.OnGoodTouch.AddListener(IncrementScore);
        EventManager.OnPerfectTouch.AddListener(IncrementBonusScore);
        EventManager.OnPlayGameButton.AddListener(ZeroScore);

        EventManager.OnFailedTouch.AddListener(SaveBestScore);
        EventManager.OnMainMenu.AddListener(SaveBestScore);
        
    }

    private void OnDisable() {
        EventManager.OnGoodTouch.RemoveListener(IncrementScore);
        EventManager.OnPerfectTouch.RemoveListener(IncrementBonusScore);
        EventManager.OnPlayGameButton.RemoveListener(ZeroScore);

        EventManager.OnFailedTouch.RemoveListener(SaveBestScore);
        EventManager.OnMainMenu.RemoveListener(SaveBestScore);
    }

    public void IncrementScore(){
        score++;
    }

    public void IncrementBonusScore(){
        score += 3;
    }

    public void ZeroScore()
    {
        score = 0;
    }

    public void SaveBestScore()
    {

        if(PlayerPrefs.HasKey(bestScoreKey))
        {
            if(score > PlayerPrefs.GetInt(bestScoreKey, 0))
            {
                PlayerPrefs.SetInt(bestScoreKey, score);
                bestScore = score;
                EventManager.OnUpdateUI.Invoke();
            }
            else
            {
                bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
                EventManager.OnUpdateUI.Invoke();
            }
        }
        else
        {
            PlayerPrefs.SetInt(bestScoreKey, score);
            bestScore = score;
        }

         //Debug.Log("Score saved! " + bestScore);
    }
    
}
