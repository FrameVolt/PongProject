﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    [SerializeField]
    private float destroyTime = 1f;
    private Animator anim;
    private AudioSource audioSource;
    

    private void Awake () {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (anim)
        destroyTime = anim.GetCurrentAnimatorStateInfo(0).length;
        if(audioSource)
        destroyTime = audioSource.clip.length > destroyTime ? audioSource.clip.length : destroyTime;
        
        Destroy(this.gameObject, destroyTime);
    }
}
