using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Stats;
using UnityEngine;

namespace AI {
    [RequireComponent(typeof(Seeker), typeof(Rigidbody2D)), RequireComponent(typeof(StatBlock))]
    public class AINavigationAgent : MonoBehaviour {

        public float stopping_distance;

        [SerializeField]
        private float find_next_waypoint_dist = 1;

        private int current_waypoint;
        private Seeker seeker;
        private Path path;
        private Vector2 facing = new Vector2(0, 1);
        private float movespeed {
            get {
                return statblock.movespeed.value;
            }
        }

        private Rigidbody2D rigidbody2d;
        private Animator animator;
        private StatBlock statblock;

        private void Awake() {
            seeker = GetComponent<Seeker>();
            rigidbody2d = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            statblock = GetComponent<StatBlock>();
        }

        private void FixedUpdate() {
            animator.SetFloat("Horizontal", facing.x);

            if (path == null) {
                animator.SetBool("walking", false);
                return;
            }

            animator.SetBool("walking", true);

            List<Vector3> waypoints = path.vectorPath;
            MoveTowardWaypoint(waypoints[current_waypoint]);

            CheckForNewWaypoint();

            CheckForEndOfPath();
        }

        private void MoveTowardWaypoint(Vector3 waypoint) {
            Vector3 direction = (waypoint - transform.position).normalized;
            Vector2 direction_2d = new Vector2(direction.x, direction.y).normalized;
            this.facing = direction_2d;
            rigidbody2d.MovePosition(rigidbody2d.position + direction_2d * movespeed * Time.fixedDeltaTime);
        }

        private void CheckForNewWaypoint() {
            List<Vector3> waypoints = path.vectorPath;
            float distance_to_current_waypoint = Vector3.Distance(transform.position, waypoints[current_waypoint]);
            if (distance_to_current_waypoint < find_next_waypoint_dist) {
                current_waypoint++;
            }
            for (int i = current_waypoint; i < waypoints.Count; i++) {
                Vector3 waypoint = waypoints[i];
                float distance_to_waypoint = Vector3.Distance(transform.position, waypoint);
                if (distance_to_waypoint < find_next_waypoint_dist) {
                    current_waypoint = i;
                } else {
                    break;
                }
            }
        }

        private void CheckForEndOfPath() {
            Vector3 end_waypoint = path.vectorPath[path.vectorPath.Count - 1];
            float distance_to_end = Vector3.Distance(transform.position, end_waypoint);
            if (distance_to_end < stopping_distance) {
                CancelPath();
            }
        }

        public void SetDestination(Vector3 destination) {
            seeker.StartPath(transform.position, destination);
        }

        public void CancelPath() {
            path = null;
            current_waypoint = 0;
        }

        private void OnPathComplete(Path path) {
            current_waypoint = 1;
            this.path = path;
        }

        private void OnEnable() {
            seeker.pathCallback += OnPathComplete;
        }

        private void OnDisable() {
            seeker.pathCallback -= OnPathComplete;
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, find_next_waypoint_dist);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, stopping_distance);
        }

        public Vector2 GetFacing() {
            return facing.normalized;
        }

        public void SetFacing(Vector2 facing) {
            this.facing = facing;
        }

    }
}