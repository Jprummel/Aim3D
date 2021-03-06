﻿using UnityEngine;
using System.Collections;

public class AnimStateHandler : MonoBehaviour
{
    Animator _playerAnim;
    // Use this for initialization
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
    }

    public void AnimState(int whichState)//Sets the animation state
    {
        _playerAnim.SetInteger("State", whichState);
    }
}
