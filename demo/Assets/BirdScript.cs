using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public float flapStrenght;
    public Rigidbody2D myRigidbody;
    public PipeSpawner pipeSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector2.up * 10;
            myRigidbody.velocity = Vector2.up * flapStrenght;


            if (pipeSpawner != null)
            {
                pipeSpawner.SpawnPipe();
            }
            else
            {
                Debug.LogError("PipeSpawner chưa được gán!");  // Thông báo lỗi trong Console nếu chưa gán      
            }
        }
    }
}
