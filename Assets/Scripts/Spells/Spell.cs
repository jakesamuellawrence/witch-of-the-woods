﻿using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace Spells {
    public abstract class Spell : ScriptableObject {
        public abstract float range { get; }

        public Note[] activation_code;

        public AudioClip activation_song;

        protected abstract void Activate(SpellBook executing_object);

        public void CheckForActivation(Note[] note_queue, SpellBook executing_object) {
            if (note_queue.Length != activation_code.Length) {
                return;
            }
            for (int i = 0; i < note_queue.Length; i++) {
                if (note_queue[i] != activation_code[i]) {
                    return;
                }
            }
            if (activation_song != null) {
                SoundManager.instance.Play(activation_song);
            }
            Activate(executing_object);
        }

    }
}