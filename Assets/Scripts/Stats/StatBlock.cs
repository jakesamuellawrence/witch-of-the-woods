using Conditions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util {
    public class StatBlock : MonoBehaviour {

        [SerializeField]
        private float base_health = 100;
        [SerializeField]
        private float base_movespeed = 10;
        [SerializeField]
        private float base_strength = 1;

        public Stat health;
        public Stat movespeed;
        public Stat strength;

        private List<Condition> conditions;

        private void Awake() {
            health = new Stat(base_health);
            movespeed = new Stat(base_movespeed);
            strength = new Stat(base_strength);

            conditions = new List<Condition>();
        }

        private void Update() {
            foreach (Condition condition in conditions) {
                condition.TickCondition();
            }
        }

        public void AddCondition(Condition condition) {
            for (int i = 0; i < conditions.Count; i++) {
                if (condition.id == conditions[i].id) {
                    conditions[i].EndCondition();
                }
            }
            condition.StartCondition();
            conditions.Add(condition);
        }

        public void RemoveCondition(Condition condition) {
            conditions.Remove(condition);
        }

    }
}