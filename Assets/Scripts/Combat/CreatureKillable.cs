using System;
using AI;
using UnityEngine;

namespace CreatureProperties {
    [RequireComponent(typeof(AIController))]
    public class CreatureKillable : Killable {
        public override void Die() {
            base.Die();

            AIController controller = GetComponent<AIController>();
            controller.enabled = false;

            // play death animation
            // Switch to corpse sprite
        }
    }
}
