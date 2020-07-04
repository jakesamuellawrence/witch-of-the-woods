using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using AI;
using Util;
using System.Runtime.InteropServices;
using CreatureProperties;
using Stats;

namespace AttackTypes {
    public abstract class Attack : ScriptableObject {

        public float distance; // distance from center of execurting agent where the check for hits is done
        public float radius;
        public float damage;

        public virtual float range {
            get {
                return (distance + radius);
            }
        }

        public virtual float hitDamage {
            get {
                return damage * statblock.strength.value;
            }
        }

        public float wind_up_time;
        public float activation_time;
        public float wind_down_time;

        protected AIController executing_controller;
        protected Animator animator;
        protected StatBlock statblock;

        public virtual void Activate(AIController executing_controller) {
            this.executing_controller = executing_controller;
            animator = executing_controller.GetComponentInChildren<Animator>();
            statblock = executing_controller.GetComponent<StatBlock>();
            CoroutineScheduler.instance.StartCoroutine(DoAttack());
        }

        protected abstract IEnumerator DoAttack();

        public virtual bool IsInRange(Transform attacker, GameObject target) {
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