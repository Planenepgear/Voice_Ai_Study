using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using Meta.WitAi;
using Meta.WitAi.Json;
using TMPro;

namespace Oculus.Voice.Demo.CharacterAnimationDemo
{
    public class CategorieBasedResponse : MonoBehaviour
    {
        private GameObject characterModle;
        private Animator animator;

        private int animationSwitchHash;

        public TextMeshProUGUI showReply;
        private string replyText;


        private void Awake()
        {
            characterModle = transform.gameObject;
        }

        void Start()
        {
            animator = characterModle.GetComponent<Animator>();
            //isGreetingHash = Animator.StringToHash("isGreeting");
        }
        
        public void UpdateAnimation(string[] values)
        {
            //// V1
            //animationSwitchHash = Animator.StringToHash("is_" + values[0]);
            //animator.SetBool(animationSwitchHash, true);
            //Invoke(nameof(AnimationBoolOff), 1f);

            //// V2
            //animator.SetTrigger("start_" + values[0]);

            // V3
            //Debug.Log(values[0] + ":" + values[1]);
            //Debug.Log(values[0].Length);
            if (values[0].Length != 0)
            {
                animationSwitchHash = Animator.StringToHash("start_" + values[0]);
                animator.SetTrigger(animationSwitchHash);
            }
        }

        //private void AnimationBoolOff()
        //{
        //    // V1
        //    animator.SetBool(animationSwitchHash, false);
        //}



        public void UpdateAnimation(string ani)
        {
            if (ani.Length != 0)
            {
                animationSwitchHash = Animator.StringToHash("start_" + ani);
                animator.SetTrigger(animationSwitchHash);

                //Debug.Log(replyText);
            }
        }

        public void GetReply(string[] values)
        {
            if(values[1].Length != 0 && values[0] == "greeting")
            {
                if(values[1] == "hello")
                {
                    replyText = "Hi";
                }
                else if (values[1] == "Hi")
                {
                    replyText = "Hello";
                }
                else if (values[1] == "Hi there")
                {
                    replyText = "Hello";
                }

                showReply.text = "Replay: " + replyText;
                UpdateAnimation("greeting");
            }

            if (values[1].Length != 0 && values[0] == "normal_dialogue")
            {
                if (values[1] == "How are you")
                {
                    replyText = "I'm fine, thank you!";
                }
                else if (values[1] == "Where are you from")
                {
                    replyText = "I'm from Korean.";
                }
                else if (values[1] == "What is your name" || values[1] == "name")
                {
                    replyText = "My name is Alice.";
                }

                showReply.text = "Replay: " + replyText;
                UpdateAnimation("normal_dialogue");
            }

            if (values[1].Length != 0 && values[0] == "say_goodbye")
            {
                if (values[1] == "Goodbye")
                {
                    replyText = "Bye bye";
                }
                else if (values[1] == "see you")
                {
                    replyText = "see you next time!";
                }
                else if (values[1] == "bye")
                {
                    replyText = "Goodbye!";
                }

                showReply.text = "Replay: " + replyText;
                UpdateAnimation("say_goodbye");
            }
        }

    }

}

