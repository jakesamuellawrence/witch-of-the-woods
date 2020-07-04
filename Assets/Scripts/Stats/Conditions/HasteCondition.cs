using Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conditions {
    public class HasteCondition : Condition {

        private float speed_multiplier;
        
        public HasteCondition(float duration, StatBlock statblock, float speed_multiplier) : base(duration, statblock, "haste") {
            this.speed_multiplier = speed_multiplier;
        }

        public override void StartCondition() {
            base.StartCondition();
            Debug.Log("Started Haste");
            calling_statblock.movespeed.AddMultiplier(speed_multiplier);
        }

        public override void EndCondition() {
            Debug.Log("Ended Haste");
            calling_statblock.movespeed.RemoveMultiplier(speed_multiplier);
            base.EndCondition();
        }

    }
}