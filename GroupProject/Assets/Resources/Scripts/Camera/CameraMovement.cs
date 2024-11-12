using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Position StartPosition = new Position { X = 8, Y = 5 };
    [SerializeField] private Position EndPosition = new Position { X = 32, Y = 15 };
    [SerializeField] public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Position playerPosition = new Position { X = player.transform.position.x, Y = player.transform.position.y };
        Position cameraPosition = new Position { X = transform.position.x, Y = transform.position.y };
        if (playerPosition.X > StartPosition.X && playerPosition.X < EndPosition.X)
        {
            cameraPosition.X = playerPosition.X;
        }
        else
        {
            if (playerPosition.X <= StartPosition.X)
            {
                cameraPosition.X = StartPosition.X;
            }
            if (playerPosition.X >= EndPosition.X)
            {
                cameraPosition.X = EndPosition.X;
            }
        }
        if (playerPosition.Y > StartPosition.Y && playerPosition.Y < EndPosition.Y)
        {
            cameraPosition.Y = playerPosition.Y;
        }
        else
        {
            if (playerPosition.Y <= StartPosition.Y)
            {
                cameraPosition.Y = StartPosition.Y;
            }
            if (playerPosition.Y >= EndPosition.Y)
            {
                cameraPosition.Y = EndPosition.Y;
            }
        }
        transform.position = new Vector3(cameraPosition.X, cameraPosition.Y, transform.position.z);
    }
}

public class Position
{
    public float X { get; set; }
    public float Y { get; set; }
}
