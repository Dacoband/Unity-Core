using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] public bool isDead = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Die()
    {
        anim.SetTrigger("dead");
        isDead = true;
    }
}
