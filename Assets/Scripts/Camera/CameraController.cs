using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera {
    public class CameraController : MonoBehaviour {

        public GameObject target;
        public float stationary_radius = 10; // camera only moves if target exeeds this radius

        private void Update() {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            float distance_to_target = (target.transform.position - transform.position).magnitude;
            if (distance_to_target > stationary_radius) {
                transform.position = Vector3.MoveTowards(transform.position,
                                                              target.transform.position,
                                                              distance_to_target - stationary_radius);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }

    }
}