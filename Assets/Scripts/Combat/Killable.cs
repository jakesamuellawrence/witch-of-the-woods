using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatureProperties {
    [RequireComponent(typeof(Collider2D))]
    public abstract class Killable : MonoBehaviour {

        public float max_health;

        private float current_health;

        public bool dead {
            get {
                return current_health <= 0;
            }
        }

        private void Awake() {
            current_health = max_health;
        }

        public void Damage(float damage) {
            current_health -= damage;
            if (current_health <= 0) {
                Die();
            }
        }

        public virtual void Die() {
            Debug.Log(name + " died.");
        }

        public float GetPercentageHealth() {
            return current_health / max_health;
        }

    }
}