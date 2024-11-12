using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFinish : MonoBehaviour
{
    [SerializeField] private int finalScore;
    [SerializeField] public GameObject DefaultUI;
    [SerializeField] public GameObject WinUI;
    void Start()
    {
        finalScore = gameObject.GetComponent<PlayerCollectFruit>().Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            other.gameObject.GetComponent<CheckpointScript>().Check();
            gameObject.GetComponent<PlayerMovement>().DisallowMoving();
            DefaultUI.SetActive(false);
            WinUI.SetActive(true);
        }
    }
}
