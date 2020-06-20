using Conditions;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.XR.Haptics;
using Util;

namespace Spells {
    public class HasteSpell : Spell {

        private readonly float haste_duration = 10f;

        public HasteSpell() {
            activation_code = new Note[] {
            Note.C,
            Note.D,
            Note.E,
            Note.F
            };
        }

        protected override void Activate(PlayerController executing_controller) {
            StatBlock statblock = executing_controller.GetComponent<StatBlock>();
            statblock.AddCondition(new HasteCondition(haste_duration, statblock));
        }
    }
}