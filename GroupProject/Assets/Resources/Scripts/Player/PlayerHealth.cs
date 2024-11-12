using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Position RespawnPosition { get; set; } = new Position { X = 8, Y = 5 };
    [SerializeField] public int Health { get; set; } = 100;
    [SerializeField] public Image HealthBar;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    void Start()
    {
        Health = Constants.PlayerHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        RespawnPosition.X = gameObject.transform.position.x;
        RespawnPosition.Y = gameObject.transform.position.y;
    }

    void Update()
    {
        if (Health <= 0)
        {
            gameObject.GetComponent<PlayerMovement>().IsAllowedToMove = false;
            anim.SetTrigger("dead");
        }
        UpdateHealthBar();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        AttackeEnemy(other);
    }
    private void AttackeEnemy(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemiesHead"))
        {
            other.gameObject.GetComponentInParent<EnemyDead>().Die();
            other.gameObject.GetComponentInParent<SlimeMovement>().Alived = false;
            string enemyName = other.gameObject.transform.parent.name.Split(' ')[0];
            gameObject.GetComponent<PlayerCollectFruit>().Score += Constants.EnemyScore[enemyName];
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        TouchEnemy(other);
    }
    private void TouchEnemy(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            bool isDead = other.gameObject.GetComponent<EnemyDead>().isDead;
            if (isDead)
            {
                return;
            }
            string enemyName = other.gameObject.name.Split(' ')[0];
            int damageDealt = Constants.EnemyDamage[enemyName];
            Health -= damageDealt;
            Health = Health <= 0 ? 0 : Health;
            KnockBack();
        }
    }
    private void KnockBack()
    {
        rb.AddForce(new Vector2(0, 150));
        anim.SetTrigger("hit");
        gameObject.GetComponent<PlayerMovement>().TriggerMoveAllowance();
    }
    public void Respawn()
    {
        Health = Constants.PlayerHealth;
        gameObject.transform.position = new Vector3(RespawnPosition.X, RespawnPosition.Y, gameObject.transform.position.z);
        gameObject.GetComponent<PlayerMovement>().IsAllowedToMove = true;
        anim.SetTrigger("respawn");
    }
    private void UpdateHealthBar(){
        HealthBar.fillAmount = (float) Health * 1.0f / Constants.PlayerHealth * 1.0f;
    }
}
