using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    public float animationDuration = 0.2f; 
        private float timer = 0.0f;
        private Animator animator;
    
        void Start()
        {
            animator = GetComponent<Animator>();
            animator.speed = 0.2f / animationDuration; 
        }
    
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= animationDuration)
            {
                animator.speed = 0.0f; 
            }
        }
}
