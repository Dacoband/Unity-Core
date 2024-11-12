using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreMenu : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    void Start()
    {
        scoreText.text = "";
        List<UserScore> scores = UserScore.GetScores();
        int count = 0;
        foreach (var score in scores)
        {
            if (count == 5)
            {
                break;
            }
            int scoreTextLength = 40;
            string space = new string(' ', scoreTextLength - score.Name.Length - score.Score.ToString().Length);
            scoreText.text += $"{score.Name}{space}{score.Score}\n";
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
