using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WinMenu : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public TMP_InputField playername;
    [SerializeField] public TMP_Text score;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
        score.text = "Your Score: " + player.GetComponent<PlayerCollectFruit>().GetScore();
    }
    public void SaveScore()
    {
        UserScore userScore = new();
        userScore.Name = playername.text.Trim().Length == 0 ? "Player" : playername.text.Trim();
        userScore.Score = player.GetComponent<PlayerCollectFruit>().Score;
        List<UserScore> userScores = UserScore.GetScores();
        userScores.Add(userScore);
        userScores.Sort((x, y) => y.Score.CompareTo(x.Score));
        UserScore.SaveScores(userScores);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
