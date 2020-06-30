using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anger {
    public class Angry : MonoBehaviour {

        [SerializeField]
        private float sleepy_threshold = 0;
        [SerializeField]
        private float calm_threshold = 20;
        [SerializeField]
        private float angry_threshold = 60;
        [SerializeField]
        private float enraged_threshold = 100;

        [SerializeField]
        private float starting_anger = 50;
        private float current_anger;

        private void Awake() {
            current_anger = starting_anger;
        }

        public AngerState anger_state {
            get {
                if (current_anger >= enraged_threshold) {
                    return AngerState.Enraged;
                } else if (current_anger >= angry_threshold) {
                    return AngerState.Angry;
                } else if (current_anger >= calm_threshold) {
                    return AngerState.Calm;
                } else if (current_anger >= sleepy_threshold) {
                    return AngerState.Sleepy;
                } else {
                    return AngerState.Asleep;
                }
            }
        }

        public void AddAnger (float anger) {
            current_anger += anger;
        }
        public void RemoveAnger (float anger) {
            current_anger -= anger;
        }

        private void Update() {
            Debug.Log(name + ", " + current_anger + ", " + anger_state);
        }

    }
}