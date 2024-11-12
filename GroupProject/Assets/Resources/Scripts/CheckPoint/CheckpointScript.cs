using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }   
    public void Check(){
        anim.SetTrigger("checked");
    }
}
