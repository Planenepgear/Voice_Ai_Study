using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using Meta.WitAi;
using Meta.WitAi.Json;

namespace Oculus.Voice.Demo.CharacterAnimationDemo
{
    public class AnimationTriggerDemo : MonoBehaviour
    {
        private Animator animator;
        private int animationSwitchHash;

        private void Awake()
        {
            animator = transform.GetComponent<Animator>();
        }

        void Start()
        {
            animationSwitchHash = Animator.StringToHash("start_greeting");
        }
        
        public void UpdateAnimation(string[] values)
        {
            if (values[0].Length != 0)
            {
                animator.SetTrigger(animationSwitchHash);
            }
        }
    }
}

