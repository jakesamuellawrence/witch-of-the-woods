using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells {
    public class SpellBook : MonoBehaviour {

        public Spell[] spells;
        public Spell displayed_spell;

        private List<Note> note_queue;

        private void Awake() {
            note_queue = new List<Note>();
        }

        public void ActivateSpells() {
            foreach (Spell spell in spells) {
                spell.CheckForActivation(note_queue.ToArray(), this);
            }
            note_queue.Clear();
        }

        public void AddNote(Note note) {
            note_queue.Add(note);
        }

        public Note[] GetNotes() {
            return note_queue.ToArray();
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, displayed_spell.range);
        }

    }
}