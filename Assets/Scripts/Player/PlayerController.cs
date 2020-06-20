using Spells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Player {
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(StatBlock))]
    public class PlayerController : MonoBehaviour {

        public float walk_speed_fraction;
        public float hold_instrument_speed_fraction;
        public List<Note> note_queue;

        private Vector2 movement_direction;
        private Vector2 facing;

        private PlayerInputActions input_actions;
        private Rigidbody2D rigidbody2d;
        private Animator animator;
        private StatBlock statblock;
        private SpellBook spellbook;

        private float movespeed {
            get {
                return statblock.movespeed.value;
            }
        }

        private void Awake() {
            input_actions = new PlayerInputActions();
            rigidbody2d = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            statblock = GetComponent<StatBlock>();
            note_queue = new List<Note>();
            spellbook = GetComponent<SpellBook>();

            input_actions.General.Movement.performed += context => movement_direction = context.ReadValue<Vector2>().magnitude <= 1 ? context.ReadValue<Vector2>() : context.ReadValue<Vector2>().normalized;
            input_actions.General.Walk.started += context => StartWalking();
            input_actions.General.Walk.canceled += context => StopWalking();
            input_actions.General.HoldInstrument.started += context => StartHoldingInstrument();
            input_actions.General.HoldInstrument.canceled += context => StopHoldingInstrument();
            input_actions.InstrumentOut.CNote.performed += context => PlayCNote();
            input_actions.InstrumentOut.DNote.performed += context => PlayDNote();
            input_actions.InstrumentOut.ENote.performed += context => PlayENote();
            input_actions.InstrumentOut.FNote.performed += context => PlayFNote();
        }

        private void PlayCNote() {
            note_queue.Add(Note.C);
        }
        private void PlayDNote() {
            note_queue.Add(Note.D);
        }
        private void PlayENote() {
            note_queue.Add(Note.E);
        }
        private void PlayFNote() {
            note_queue.Add(Note.F);
        }

        private void StartHoldingInstrument() {
            input_actions.InstrumentOut.Enable();
            statblock.movespeed.AddMultiplier(hold_instrument_speed_fraction);
        }
        private void StopHoldingInstrument() {
            input_actions.InstrumentOut.Disable();
            statblock.movespeed.RemoveMultiplier(hold_instrument_speed_fraction);
            spellbook.ActivateSpells(note_queue.ToArray());
            note_queue.Clear();
        }

        private void StartWalking() {
            statblock.movespeed.AddMultiplier(walk_speed_fraction);
        }
        private void StopWalking() {
            statblock.movespeed.RemoveMultiplier(walk_speed_fraction);
        }

        private void Update() {
            animator.SetFloat("Horizontal", facing.x);
            animator.SetFloat("Vertical", facing.y);
            animator.SetFloat("Speed", (movement_direction * movespeed).magnitude);

            //string to_print = "";
            //foreach (Note note in note_queue) {
            //    to_print = to_print + note.ToString();
            //}
            //Debug.Log(to_print);
        }

        private void FixedUpdate() {
            ConsiderMovement();
        }

        private void ConsiderMovement() {
            if (movement_direction != Vector2.zero) {
                facing = movement_direction;
            }

            rigidbody2d.MovePosition(rigidbody2d.position + movement_direction * movespeed * Time.fixedDeltaTime);
        }

        private void OnEnable() {
            input_actions.Enable();
            input_actions.InstrumentOut.Disable();
        }

        private void OnDisable() {
            input_actions.Disable();
        }

    }
}