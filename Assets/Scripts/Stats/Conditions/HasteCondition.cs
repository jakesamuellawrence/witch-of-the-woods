using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Conditions {
    public class HasteCondition : Condition {

        private readonly float speed_multiplier = 2;
        
        public HasteCondition(float duration, StatBlock statblock) : base(duration, statblock, "haste") {}

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