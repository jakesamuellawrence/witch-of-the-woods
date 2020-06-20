using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace AI {
    public abstract class AITask {

        private readonly float same_importance_distance = 4f;
        private readonly float importance_constant;

        protected AIController executing_controller;
        protected GameObject target;
        protected int priority;
        protected bool inverse_distance;

        private IEnumerator task_coroutine;

        public AITask(AIController executing_controller, GameObject target, int priority, bool inverse_distance) {
            this.executing_controller = executing_controller;
            this.target = target;
            this.priority = priority;
            this.inverse_distance = inverse_distance;
            importance_constant = Mathf.Pow(same_importance_distance, 4);
        }

        public virtual void StartTask() {
            task_coroutine = DoTask();
            CoroutineScheduler.instance.StartCoroutine(task_coroutine);
        }

        public abstract IEnumerator DoTask();

        public virtual void PauseTask() {
            CoroutineScheduler.instance.StopCoroutine(task_coroutine);
        }

        public virtual void FinishTask() {
            PauseTask();
            executing_controller.FinishTask(this);
        }

        public virtual float CalculateImportance() {
            Vector3 location = target.transform.position;
            float sqr_distance_to_location = (location - executing_controller.transform.position).sqrMagnitude;
            float distance_factor = inverse_distance ? importance_constant / sqr_distance_to_location : sqr_distance_to_location;
            return priority * distance_factor;
        }

    }
}