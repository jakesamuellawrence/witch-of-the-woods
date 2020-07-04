using Conditions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stats;

namespace Spells {
    [CreateAssetMenu(fileName = "HasteSpell", menuName = "Spells/HasteSpell")]
    public class HasteSpell : Spell {

        public float speed_multiplier;
        public float duration;
        
        public override float range {
            get {
                return 0;
            }
        }

        protected override void Activate(SpellBook executing_object) {
            StatBlock statblock = executing_object.GetComponent<StatBlock>();
            statblock.AddCondition(new HasteCondition(duration, statblock, speed_multiplier));
        }
    }
}