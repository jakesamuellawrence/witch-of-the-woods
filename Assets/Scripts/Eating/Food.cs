using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemProperties {
    public class Food : MonoBehaviour {

        public float eat_radius = 2; // how far away something has to be to eat this
        public float eat_time = 4; // how long it takes for this food to be eaten
        public float anger_healed = 20;

        public void FinishEating() {
            gameObject.SetActive(false);
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, eat_radius);
        }

    }
}