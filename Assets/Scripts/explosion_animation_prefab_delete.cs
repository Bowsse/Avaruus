using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_animation_prefab_delete : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.050f);
    }
}