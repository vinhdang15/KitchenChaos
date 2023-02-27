using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Player player;
    Animator                animator;
    const string            IS_WALKING = "IsWalking";
    
    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        animator.SetBool(IS_WALKING,player.IsWalking());
    }
}
