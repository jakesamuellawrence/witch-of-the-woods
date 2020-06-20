using AI;
using AITasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatureProperties {
    [RequireComponent(typeof(AIController))]
    public class Follower : MonoBehaviour {

        public float follow_distance = 2;
        public GameObject target;

        [SerializeField]
        private int follow_priority = 60;

        private AIController controller;

        private void Awake() {
            controller = GetComponent<AIController>();
        }

        private void Start() {
            controller.RegisterTask(new FollowTask(controller, target, follow_priority, follow_distance));
        }

    }
}