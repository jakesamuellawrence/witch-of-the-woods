using CreatureProperties;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class UIHealthBar : MonoBehaviour {

        public Killable target;

        private Slider slider;

        private void Awake() {
            slider = GetComponent<Slider>();
        }

        private void Start() {
            if (target == null) {
                target = GetComponentInParent<Killable>();
            }
        }

        private void Update() {
            slider.value = target.GetPercentageHealth();
        }
    }
}