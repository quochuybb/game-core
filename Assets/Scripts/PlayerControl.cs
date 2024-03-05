using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
        public float moveSpeed;
        private bool isMoving;
        private Vector2 input;
        public LayerMask solidOjectLayer;
        public Rigidbody2D rb;
        public Camera cam;
        private Vector2 mousePos;
        void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal"); 
            input.y = Input.GetAxisRaw("Vertical"); 
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
           
        }
    
        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
}
