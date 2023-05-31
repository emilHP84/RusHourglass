using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator anim;
    public float time;

    void Start() {
        time = 0;
        anim = GetComponent<Animator>();
    }

    private void Update() {
        time += Time.deltaTime;
    }

    public void RightAnim() {
        time = 0;
        anim.SetBool("isStraffing", true);
        if (time >= 1) {
            anim.SetBool("isStraffing", false);
        }
    }
    
}
