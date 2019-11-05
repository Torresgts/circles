using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    void Awake()
    {
      EventManager.IncrementScoreText.AddListener(IncrementScoreText);
      
      scoreText = this.GetComponent<TMP_Text>();
    }

    public void IncrementScoreText()
    {
        scoreText.text = Score.score.ToString();
    }
    
}
