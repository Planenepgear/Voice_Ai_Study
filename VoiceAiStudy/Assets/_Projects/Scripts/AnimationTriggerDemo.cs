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
        private int animationSwitchHash2;

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
            animationSwitchHash2 = Animator.StringToHash("start_" + values[2]);

            if (values[0].Length != 0)
            {
                if (values[1] == "Hi")
                {
                    animator.SetTrigger(animationSwitchHash);
                }

            }

            if (values[2].Length != 0)
            {
                if (values[3] == "bye")
                {
                    animator.SetTrigger(animationSwitchHash2);
                }
            }
        }
    }
}

