using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stats {
    public class Stat {

        private float base_value;
        private List<float> modifiers;
        private List<float> multipliers;

        public Stat(float base_value) {
            this.base_value = base_value;
            modifiers = new List<float>();
            multipliers = new List<float>();
        }

        public float value {
            get {
                float value = base_value;
                foreach (float modifier in modifiers) {
                    value = value + modifier;
                }
                foreach (float multiplier in multipliers) {
                    value = value * multiplier;
                }
                return value;
            }
        }

        public void AddModifier(float modifier) {
            modifiers.Add(modifier);
        }
        public void RemoveModifier(float modifier) {
            modifiers.Remove(modifier);
        }

        public void AddMultiplier(float multiplier) {
            multipliers.Add(multiplier);
        }
        public void RemoveMultiplier(float multiplier) {
            multipliers.Remove(multiplier);
        }

    }
}