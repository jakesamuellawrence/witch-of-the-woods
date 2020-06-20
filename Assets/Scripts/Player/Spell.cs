using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace Spells {
    public abstract class Spell {

        protected Note[] activation_code;

        protected abstract void Activate(PlayerController executing_controller);

        public void CheckForActivation(Note[] note_queue, PlayerController executing_controller) {
            if (note_queue.Length != activation_code.Length) {
                return;
            }
            for (int i = 0; i < note_queue.Length; i++) {
                if (note_queue[i] != activation_code[i]) {
                    return;
                }
            }
            Activate(executing_controller);
        }

    }
}