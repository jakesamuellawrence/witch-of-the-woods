using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using AI;
using Util;
using System.Runtime.InteropServices;
using CreatureProperties;

namespace AttackTypes {
    public abstract class Attack : ScriptableObject {

        public float distance; // distance from center of execurting agent where the check for hits is done
        public float radius;
        public float damage;
        public float pointless;

        public virtual float range {
            get {
                return (distance + radius);
            }
        }

        public float wind_up_time;
        public float wind_down_time;

        protected AIController executing_controller;

        public virtual void Activate(AIController executing_controller) {
            this.executing_controller = executing_controller;
            CoroutineScheduler.instance.StartCoroutine(DoAttack());
        }

        protected abstract IEnumerator DoAttack();

        public virtual bool IsInRange(Transform attacker, GameObject target) {
            //float distance_to_target = (target.position - attacker.position).magnitude;
            //return distance_to_target < range;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(attacker.position.x, attacker.position.y), range);
            foreach (Collider2D collider in colliders) {
                if (collider.gameObject == target) {
                    return true;
                }
            }
            return false;
        }

    }

}