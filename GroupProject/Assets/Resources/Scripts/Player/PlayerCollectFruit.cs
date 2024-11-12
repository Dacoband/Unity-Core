using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCollectFruit : MonoBehaviour
{
    [SerializeField] public int Score { get; set; }
    [SerializeField] public AudioClip CollectSound;
    [SerializeField] public TMP_Text txtScore;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            if (other.gameObject.GetComponent<FruitCollect>().Collected)
            {
                return;
            }
            other.gameObject.GetComponent<FruitCollect>().Collected = true;
            string fruitName = other.gameObject.name.Split(' ')[0];
            Debug.Log("Fruit: " + fruitName);
            Score += Constants.FruitScore[fruitName];
            other.gameObject.GetComponent<FruitCollect>().PlayCollectAnimation();
            AudioSource.PlayClipAtPoint(CollectSound, transform.position);
        }
    }

    void Update()
    {
        txtScore.text = GetScore();
    }

    public string GetScore(){
        string score = "00000000";
        string scoreStr = Score.ToString();
        return score.Substring(0, score.Length - scoreStr.Length) + scoreStr;
    }
}
