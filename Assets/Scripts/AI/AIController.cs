using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AI {
    [RequireComponent(typeof(AIController))]
    public class AIController : MonoBehaviour {

        private bool busy;

        [SerializeField]
        private float change_current_task_rate = 0.1f;

        private List<AITask> tasks;
        private AITask current_task;

        private AINavigationAgent navigator;

        private void Awake() {
            navigator = GetComponent<AINavigationAgent>();
            tasks = new List<AITask>();
            InvokeRepeating("ChangeCurrentTask", change_current_task_rate, change_current_task_rate);
        }

        public void SwitchToTask(AITask task) {
            if (current_task != null) {
                current_task.PauseTask();
            }
            current_task = task;
            current_task.StartTask();
        }

        public void ChangeCurrentTask() {
            if (tasks.Count == 0 || IsBusy()) {
                return;
            }

            AITask most_important_task = GetMostImportantTask();
            if (most_important_task != current_task) {
                SwitchToTask(most_important_task);
            }
        }

        public void RegisterTask(AITask task) {
            tasks.Add(task);
        }

        public void FinishTask(AITask task) {
            current_task = null;
            tasks.Remove(task);
            ChangeCurrentTask();
        }

        public void RemoveTasksOfType<T>() {
            tasks.RemoveAll((task) => task is T);
        }

        private void OnDisable() {
            if (current_task != null) {
                current_task.PauseTask();
            }
            CancelInvoke();
        }

        public void IssueMoveCommand(Vector3 destination, float stopping_distance) {
            navigator.stopping_distance = stopping_distance;
            navigator.SetDestination(destination);
        }

        public void CancelMoveCommand() {
            navigator.CancelPath();
        }

        private AITask GetMostImportantTask() {
            AITask most_important_task = tasks[0];
            float highest_importance = tasks[0].CalculateImportance();
            for (int i = 0; i < tasks.Count; i++) {
                float importance = tasks[i].CalculateImportance();
                if (importance > highest_importance) {
                    most_important_task = tasks[i];
                    highest_importance = importance;
                }
            }
            return most_important_task;
        }

        public void PointAt(Vector3 point) {
            Vector3 direction = (point - transform.position);
            Vector3 direction2d = new Vector2(direction.x, direction.y);
            SetFacing(direction2d);
        }

        public void SetFacing(Vector2 facing) {
            navigator.SetFacing(facing);
        }

        public Vector2 GetFacing() {
            return navigator.GetFacing();
        }

        public void SetBusy(bool busy) {
            this.busy = busy;
        }

        public bool IsBusy() {
            return this.busy;
        }

    }
}