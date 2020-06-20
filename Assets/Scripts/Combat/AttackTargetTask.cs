using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using AttackTypes;
using Util;
using CreatureProperties;
using System.Runtime.InteropServices;
using System.Reflection;

namespace AITasks {
    public class AttackTargetTask : AITask {

        private readonly float repeat_rate = 0.1f;

        private Attack[] available_attacks;

        private Attack selected_attack;

        new private Killable target;

        public AttackTargetTask(AIController executing_controller, Killable target, Attack[] attacks, int priority)
            : base(executing_controller, target.gameObject, priority, true) {
            this.available_attacks = attacks;
            this.target = target;
            if (available_attacks.Length == 0) {
                Debug.LogWarning(executing_controller.name + " has no assigned attacks!");
            }
        }

        public override IEnumerator DoTask() {
            while (true) {
                if (target.dead) {
                    FinishTask();
                }
                if (selected_attack == null) {
                    SelectNewAttack();
                } else if (executing_controller.IsBusy() == false) {
                    if (selected_attack.IsInRange(executing_controller.transform, target.gameObject)) {
                        executing_controller.CancelMoveCommand();
                        executing_controller.PointAt(target.transform.position);
                        selected_attack.Activate(executing_controller);
                        SelectNewAttack();
                    } else {
                        executing_controller.IssueMoveCommand(target.transform.position, selected_attack.range);
                    }
                }
                yield return CoroutineScheduler.instance.WaitForSeconds(repeat_rate);
            }
        }

        private void SelectNewAttack() {
            int index = Random.Range(0, available_attacks.Length);
            selected_attack = available_attacks[index];
        }
    }
}