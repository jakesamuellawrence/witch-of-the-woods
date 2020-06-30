using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemProperties;
using Util;
using Anger;

namespace AITasks
{
    public class EatFoodTask : AITask
    {

        private readonly float repeat_rate = 0.25f;

        private Food target_food;

        public EatFoodTask(AIController executing_controller, Food target_food, int priority)
            : base(executing_controller, target_food.gameObject, priority, true) {
            this.target_food = target_food;
        }

        public override void StartTask() {
            base.StartTask();
            executing_controller.IssueMoveCommand(target.transform.position, target_food.eat_radius);
        }

        public override IEnumerator DoTask() {
            while (true) {
                float distance_to_target = Vector3.Distance(executing_controller.transform.position, target_food.transform.position);
                if (distance_to_target < target_food.eat_radius) {
                    executing_controller.SetBusy(true);
                    yield return CoroutineScheduler.instance.WaitForSeconds(target_food.eat_time);
                    target_food.FinishEating();

                    Angry angry = executing_controller.GetComponent<Angry>();
                    angry.RemoveAnger(target_food.anger_healed);

                    executing_controller.SetBusy(false);
                    FinishTask();
                } else {
                    executing_controller.IssueMoveCommand(target.transform.position, target_food.eat_radius);
                }
                yield return CoroutineScheduler.instance.WaitForSeconds(repeat_rate);
            }
        }

        public override void PauseTask() {
            base.PauseTask();
            Debug.Log("Paused Eat");
        }

    }
}
