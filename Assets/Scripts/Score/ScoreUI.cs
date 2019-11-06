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
        scoreText = this.GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        EventManager.OnGoodTouch.AddListener(IncrementScoreText);
        EventManager.OnPerfectTouch.AddListener(IncrementScoreText);
        EventManager.OnPlayGame.AddListener(IncrementScoreText);
    }

    private void OnDisable()
    {
        EventManager.OnGoodTouch.RemoveListener(IncrementScoreText);
        EventManager.OnPerfectTouch.RemoveListener(IncrementScoreText);
        EventManager.OnPlayGame.RemoveListener(IncrementScoreText);
    }

    public void IncrementScoreText()
    {
        scoreText.text = Score.score.ToString();
    }

}
