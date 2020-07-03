using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells {
    public class SpellBook : MonoBehaviour {

        private Spell[] spells;

        private void Awake() {
            spells = new Spell[] {
            new HasteSpell(),
            new ArpeggioRiff()
        };
        }

        public void ActivateSpells(Note[] note_queue) {
            foreach (Spell spell in spells) {
                spell.CheckForActivation(note_queue, GetComponent<PlayerController>());
            }
        }

    }
}