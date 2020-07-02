using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using AITasks;
using ItemProperties;

namespace CreatureProperties {
    [RequireComponent(typeof(AIController))]
    public class Hungry : MonoBehaviour {

        [SerializeField]
        private int food_priority = 20;
        [SerializeField]
        private float food_detect_radius = 10;
        [SerializeField]
        private float food_detect_rate = 1f;

        private List<Food> known_food;

        private AIController controller;

        private void Awake() {
            controller = GetComponent<AIController>();
            known_food = new List<Food>();
        }

        private void Start() {
            InvokeRepeating("CheckForFood", 0.1f, food_detect_rate);
        }

        public void CheckForFood() {
            Food[] foods = FindObjectsOfType<Food>();
            foreach (Food food in foods) {
                float distance_to_food = Vector3.Distance(transform.position, food.transform.position);
                if (!known_food.Contains(food) && distance_to_food < food_detect_radius) {
                    RegisterFood(food);
                }
            }
        }

        public void RegisterFood(Food food) {
            controller.RegisterTask(new EatFoodTask(controller, food, food_priority));
            known_food.Add(food);
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, food_detect_radius);
        }

    }
}