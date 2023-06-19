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

        [SerializeField] TextMeshProUGUI showReply;
        //private bool isLock = false;  // When there are four values locking is only used to two values of the method.
        private string replyTextSingle;
        private string replyTextDouble;


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

        private void BackToIdleAnimation()
        {
            animator.SetTrigger("start_back_idle");
        }


        public void GetSingleReply(string[] values)
        {
            //if (values[3].Length == 0)
            if (values.Length == 2)
            {
                if (values[1].Length != 0 && values[0] == "greeting")
                {
                    if (values[1] == "hello")
                    {
                        replyTextSingle = "Hi";
                    }
                    else if (values[1] == "Hi")
                    {
                        replyTextSingle = "Hello";
                    }
                    else if (values[1] == "Hi there")
                    {
                        replyTextSingle = "Hello";
                    }

                    showReply.text = "Replay: " + replyTextSingle;
                    UpdateAnimation("greeting");
                }
                else if (values[1].Length != 0 && values[0] == "normal_dialogue")
                {
                    if (values[1] == "How are you")
                    {
                        replyTextSingle = "I'm fine, thank you!";
                    }
                    else if (values[1] == "Where are you from")
                    {
                        replyTextSingle = "I'm from Korean.";
                    }
                    else if (values[1] == "What is your name" || values[1] == "name")
                    {
                        replyTextSingle = "My name is Alice.";
                    }

                    showReply.text = "Replay: " + replyTextSingle;
                    UpdateAnimation("normal_dialogue");
                }
                else if (values[1].Length != 0 && values[0] == "say_goodbye")
                {
                    if (values[1] == "Goodbye")
                    {
                        replyTextSingle = "Bye bye";
                    }
                    else if (values[1] == "see you")
                    {
                        replyTextSingle = "see you next time!";
                    }
                    else if (values[1] == "bye")
                    {
                        replyTextSingle = "Goodbye!";
                    }

                    showReply.text = "Replay: " + replyTextSingle;
                    UpdateAnimation("say_goodbye");
                }

                BackToIdleAnimation();

                Debug.Log("Single Reply Mod");
                Debug.Log(values.Length);
            }
        }

        public string GetSingleReply(string aniValue, string queValue)
        {
            if (queValue.Length != 0 && aniValue == "greeting")
            {
                if (queValue == "hello")
                {
                    replyTextSingle = "Hi";
                }
                else if (queValue == "Hi")
                {
                    replyTextSingle = "Hello";
                }
                else if (queValue == "Hi there")
                {
                    replyTextSingle = "Hello";
                }

                //showReply.text = "Replay: " + replyTextSingle;
                UpdateAnimation("greeting");
            }
            else if (queValue.Length != 0 && aniValue == "normal_dialogue")
            {
                if (queValue == "How are you")
                {
                    replyTextSingle = "I'm fine, thank you!";
                }
                else if (queValue == "Where are you from")
                {
                    replyTextSingle = "I'm from Korea.";
                }
                else if (queValue == "What is your name" || queValue == "name")
                {
                    replyTextSingle = "My name is Alice.";
                }

                //showReply.text = "Replay: " + replyTextSingle;
                UpdateAnimation("normal_dialogue");
            }
            else if (queValue.Length != 0 && aniValue == "say_goodbye")
            {
                if (queValue == "Goodbye")
                {
                    replyTextSingle = "Bye bye";
                }
                else if (queValue == "see you")
                {
                    replyTextSingle = "see you next time!";
                }
                else if (queValue == "bye")
                {
                    replyTextSingle = "Goodbye!";
                }

                //showReply.text = "Replay: " + replyTextSingle;
                UpdateAnimation("say_goodbye");
            }

            return replyTextSingle;
        }

        public void GetDoubleReply(string[] values)
        {
            if (values[0].Length != 0 && values[2].Length != 0)
            {
                replyTextDouble = GetSingleReply(values[0], values[1]) + ", " + GetSingleReply(values[2], values[3]);
            }
            else if (values[0].Length != 0)
            {
                replyTextDouble = GetSingleReply(values[0], values[1]);
            }
            else if (values[2].Length != 0)
            {
                replyTextDouble = GetSingleReply(values[2], values[3]);
            }
            else if (values[4].Length != 0)
            {
                replyTextDouble = GetSingleReply(values[4], values[5]);
            }

            showReply.text = "Replay: " + replyTextDouble;
            //BackToIdleAnimation();

            Debug.Log("Double Reply Mod");
            Debug.Log(values.Length);
        }
    }



}

