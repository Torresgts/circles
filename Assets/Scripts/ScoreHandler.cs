using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreHandler : MonoBehaviour
{
    [SerializeField]
    public static int score;

    public TMP_Text scoretext;

    private void Update() {
        scoretext.text = score.ToString();
    }


}
