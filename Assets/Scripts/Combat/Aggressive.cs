using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackTypes;
using AI;
using UnityEditor.Graphs;
using AITasks;
using Anger;
using System.Threading;

namespace CreatureProperties {
    [RequireComponent(typeof(AIController)), RequireComponent(typeof(Angry))]
    public class Aggressive : MonoBehaviour {

        public Attack[] assigned_attacks;
        private Attack[] attacks;
        private List<Killable> known_targets;

        [SerializeField]
        private int attack_priority = 40;
        [SerializeField]
        private float target_detect_radius = 8;
        [SerializeField]
        private float target_detect_rate = 1f;

        public Attack displayed_attack;

        private AIController controller;
        private Angry angry;

        private void Awake() {
            controller = GetComponent<AIController>();
            angry = GetComponent<Angry>();

            known_targets = new List<Killable>();

            attacks = new Attack[assigned_attacks.Length];
            for (int i = 0; i < assigned_attacks.Length; i++) {
                attacks[i] = Instantiate(assigned_attacks[i]);
            }
        }

        private void Start() {
            InvokeRepeating("CheckForTargets", 0.1f, target_detect_rate);
        }

        private void CheckForTargets() {
            if (angry.anger_state >= AngerState.Calm) {
                return;
            }
            Killable[] targets = FindObjectsOfType<Killable>();
            foreach (Killable target in targets) {
                float distance_to_target = Vector3.Distance(transform.position, target.transform.position);
                if (!known_targets.Contains(target) && distance_to_target < target_detect_radius && target != GetComponent<Killable>()) {
                    RegisterTarget(target);
                }
            }
        }

        private void RegisterTarget(Killable target) {
            known_targets.Add(target);
            controller.RegisterTask(new AttackTargetTask(controller, target, attacks, attack_priority));
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;

            Vector3 facing3d = new Vector3(0, -1, 0);
            if (controller != null) {
                Vector2 facing = controller.GetFacing();
                facing3d.x = facing.x;
                facing3d.y = facing.y;
            }

            Gizmos.DrawWireSphere(transform.position + facing3d * displayed_attack.distance, displayed_attack.radius);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, target_detect_radius);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, displayed_attack.range);
        }

    }
}