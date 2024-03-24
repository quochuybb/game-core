using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
        public float moveSpeed;
        [SerializeField] private bool isMoving;
        [SerializeField] private Vector2 input;
        public LayerMask solidOjectLayer;
        public Rigidbody2D rb;
        public Camera cam;
        [SerializeField] private Canvas shopScreen;
        [SerializeField] private int maxHealth = 10;
        [SerializeField] private int currentHealth;
        [SerializeField] private Vector2 mousePos;
        [SerializeField] private bool ispaused = false;
        public HearBar healthBar; 
        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                takedmg(1);
            }
            else if (collision.gameObject.tag == "Shop")
            {
                shopScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

        void Update()
        {
            input.x = Input.GetAxisRaw("Horizontal"); 
            input.y = Input.GetAxisRaw("Vertical"); 
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPause();
            }
            

        }
    
        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

        }

        private void isPause()
        {
            ispaused = !ispaused;
            if (ispaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private void takedmg(int damge)
        {
            currentHealth -= damge;
            healthBar.SetHealth(currentHealth);
        }
        

}
