using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollect : MonoBehaviour
{
    [SerializeField] public bool Collected { get; set; } = false;
    public void PlayCollectAnimation()
    {
        GetComponent<Animator>().SetTrigger("collect");
    }

    public void DestroyFruit()
    {
        Destroy(gameObject);
    }
}
