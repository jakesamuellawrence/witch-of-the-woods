using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace UI {
    public class UINoteDisplay : MonoBehaviour {

        public GameObject[] note_prefabs;
        public PlayerController player_controller;

        private float old_notes_length = 0;

        private List<GameObject> note_ui_elements;

        private void Awake() {
            note_ui_elements = new List<GameObject>();
        }

        private void Update() {
            Note[] notes = player_controller.note_queue.ToArray();
            if (notes.Length != old_notes_length) {
                UpdateDisplay(notes);
                old_notes_length = notes.Length;
            }
        }

        private void UpdateDisplay(Note[] notes) {
            DestroyOldElements();
            MakeNewElements(notes);
        }

        private void DestroyOldElements() {
            foreach (GameObject element in note_ui_elements) {
                Destroy(element);
            }
            note_ui_elements.Clear();
        }

        private void MakeNewElements(Note[] notes) {
            Vector3 current_position = this.transform.position + new Vector3(-GetComponent<RectTransform>().rect.width/2 + note_prefabs[0].GetComponent<RectTransform>().rect.width/2, 0, 0);
            foreach (Note note in notes) {
                GameObject new_note_element = Instantiate(note_prefabs[(int)note], current_position, Quaternion.identity, this.transform);
                note_ui_elements.Add(new_note_element);
                current_position.x = current_position.x + note_prefabs[0].GetComponent<RectTransform>().rect.width;
            }
        }


    }
}