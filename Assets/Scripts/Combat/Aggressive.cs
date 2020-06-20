using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackTypes;
using AI;
using UnityEditor.Graphs;
using AITasks;

namespace CreatureProperties {
    [RequireComponent(typeof(AIController))]
    public class Aggressive : MonoBehaviour {

        public Attack[] assigned_attacks;

        private Attack[] attacks;

        [SerializeField]
        private int attack_priority = 40;
        [SerializeField]
        private float target_detect_radius = 8;

        public Attack displayed_attack;

        private AIController controller;

        private void Awake() {
            controller = GetComponent<AIController>();

            attacks = new Attack[assigned_attacks.Length];
            for (int i = 0; i < assigned_attacks.Length; i++) {
                attacks[i] = Instantiate(assigned_attacks[i]);
            }
        }

        private void Start() {
            Killable[] targets = FindObjectsOfType<Killable>();
            foreach (Killable target in targets) {
                if (target.gameObject != gameObject) {
                    controller.RegisterTask(new AttackTargetTask(controller, target, attacks, attack_priority));
                }
            }
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