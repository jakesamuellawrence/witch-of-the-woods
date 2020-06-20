//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Util;

//namespace Player {
//    [RequireComponent(typeof(Rigidbody2D))]
//    public class PlayerControllerOld : MonoBehaviour {

//        public float max_speed;
//        public float acceleration;
//        public float dash_distance;
//        public float dash_time;
//        public float dash_cooldown;
//        public PlayerInputActions input_actions;

//        private float current_speed;
//        private Vector2 facing;

//        private Animator animator;
//        private Rigidbody2D rigidbody2d;
//        private Vector2 movement;

//        private void Awake() {
//            rigidbody2d = GetComponent<Rigidbody2D>();
//            animator = GetComponentInChildren<Animator>();
//            movement = new Vector2(0, 0);
//        }

//        private void Update() {
//            movement = Vector2.zero;

//            Vector2 move_direction = InputHandler.instance.GetMoveDirection();

//            if (move_direction != Vector2.zero && current_speed < max_speed) {
//                current_speed += acceleration * Time.deltaTime;
//            } else if (current_speed > 0) {
//                current_speed -= acceleration * Time.deltaTime;
//            } else {
//                current_speed = 0;
//            }

//            movement += InputHandler.instance.GetFacing() * current_speed;
//            Vector2 facing = InputHandler.instance.GetFacing();

//            animator.SetFloat("Speed", current_speed);
//            animator.SetFloat("Horizontal", facing.x);
//            animator.SetFloat("Vertical", facing.y);

//            Check if the player is dashing
//            if (Input.GetButtonDown("Dash")) {
//                StartCoroutine(Dash());
//            }

//        }

//        private IEnumerator Dash() {
//            Vector2 dash_direction = InputHandler.instance.GetFacing();
//            float distance_moved = 0;
//            float dash_speed = dash_distance / dash_time;
//            while (distance_moved < dash_distance) {
//                distance_moved += dash_speed * Time.deltaTime;
//                movement += dash_direction * dash_speed;
//                yield return null;
//            }
//        }

//        private void FixedUpdate() {
//            rigidbody2d.MovePosition(rigidbody2d.position + movement * Time.deltaTime);
//        }

//    }
//}