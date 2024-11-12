using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] public bool Alived { get; set; } = true;
    [SerializeField] private bool Moving { get; set; } = false;
    [SerializeField] public bool IsFacingLeft { get; set; } = true;
    [SerializeField] public Position StartPosition { get; set; } = new Position { X = 0, Y = 0 };
    [SerializeField] public Position EndPosition { get; set; } = new Position { X = 0, Y = 0 };
    [SerializeField] private float StandingTime { get; set; }
    [SerializeField] private float StandingTimer = 0.0f;
    [SerializeField] private bool IsAllowedToMove { get; set; } = true;
    [SerializeField] public GameObject player;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartPosition.X = transform.position.x - 5;
        EndPosition.X = transform.position.x + 5;
        StandingTime = 2.0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {   
        Position playerPosition = new Position { X = player.transform.position.x, Y = player.transform.position.y };
        if (playerPosition.X < StartPosition.X || playerPosition.X > EndPosition.X)
        {
            speed = 1.0f;
            Move();
        }else{
            speed = 3.0f;
            ChasePlayer(playerPosition);
        }
    }
    private void ChasePlayer(Position playerPosition)
    {
        if (Alived)
        {
            if (IsAllowedToMove)
            {
                if (transform.position.x < playerPosition.X)
                {
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
                SetMoving();
            }
        }
    }
    private void Move()
    {
        if (Alived)
        {
            if (IsAllowedToMove)
            {
                if (transform.position.x < StartPosition.X)
                {
                    IsFacingLeft = false;
                }
                if (transform.position.x > EndPosition.X)
                {
                    IsFacingLeft = true;
                }
                if (IsFacingLeft)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
                SetMoving();
            }

            //reach start or end position
            if (transform.position.x <= StartPosition.X || transform.position.x >= EndPosition.X)
            {
                StandingTimer += Time.deltaTime;
                if (StandingTimer >= StandingTime)
                {
                    StandingTimer = 0;
                    IsFacingLeft = !IsFacingLeft;
                    IsAllowedToMove = true;
                    return;
                }
                IsAllowedToMove = false;
                Moving = false;
                SetMoving();
            }
        }
    }
    private void MoveLeft()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Moving = true;
    }
    private void MoveRight()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Moving = true;
    }
    private void SetMoving()
    {
        if (Moving)
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("isStanding", false);
        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("isStanding", true);
        }
    }
    public void DestroySlime()
    {
        Destroy(gameObject);
    }
}
