using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public float flapStrenght;
    public Rigidbody2D myRigidbody;
    private bool levelStarted;
    public GameObject gameObjected;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI welcomeText;
    private bool isGameOver;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    [SerializeField] private AudioClip flapSound;
    //public TextMeshProUGUI restartText;
    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStarted = false;
        myRigidbody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        welcomeText.gameObject.SetActive(true);
        isGameOver = false;
        gameOverText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            Debug.Log("Flap Strength: " + flapStrenght);
            Debug.Log("PlaySound Instance: " + PlaySound.instance);
            Debug.Log("GameObjected: " + gameObjected);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRigidbody.velocity = Vector2.up * flapStrenght;
                levelStarted = true;
                welcomeText.gameObject.SetActive(false);
                myRigidbody.gravityScale = 5;
                gameObjected.GetComponent<PipeSpawner>().enableSpawning = true; // This might be the line causing the exception
                PlaySound.instance.PlaySourceSound(flapSound);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                ReloadScence();
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        myRigidbody.velocity = Vector2.zero;
        gameObjected.GetComponent<PipeSpawner>().enableSpawning = false;
        gameOverText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isGameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void ReloadScence()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
