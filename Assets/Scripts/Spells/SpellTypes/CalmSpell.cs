using Anger;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

namespace Spells {
    [CreateAssetMenu(fileName = "CalmSpell", menuName = "Spells/CalmSpell")]
    public class CalmSpell : Spell {

        public float anger_healed;
        public float effect_radius;

        public override float range {
            get {
                return effect_radius;
            }
        }

        protected override void Activate(SpellBook executing_object) {
            Angry[] angries = FindObjectsOfType<Angry>();
            foreach (Angry angry in angries) {
                float distance = Vector3.Distance(executing_object.transform.position, angry.transform.position);
                if (distance < range) {
                    angry.RemoveAnger(anger_healed);
                }
            }
        }
    }
}