using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace AITasks {
    public class FollowTask : AITask {

        private readonly float repeat_rate = 0.5f;

        private float follow_distance;

        public FollowTask(AIController executing_controller, GameObject target, int priority, float follow_distance)
            : base(executing_controller, target, priority, false) {
            this.target = target;
            this.follow_distance = follow_distance;
        }

        public override void StartTask() {
            base.StartTask();
            executing_controller.IssueMoveCommand(target.transform.position, follow_distance);
            Debug.Log("Started Follow");
        }

        public override IEnumerator DoTask() {
            while (true) {
                Debug.Log("doing follow task");
                float distance_to_target = Vector3.Distance(executing_controller.transform.position, target.transform.position);
                if (distance_to_target > follow_distance) {
                    executing_controller.IssueMoveCommand(target.transform.position, follow_distance);
                }
                yield return CoroutineScheduler.instance.WaitForSeconds(repeat_rate);
            }
        }

        public override void PauseTask() {
            base.PauseTask();
            executing_controller.CancelMoveCommand();
            Debug.Log("Paused Follow");
        }
    }
}
