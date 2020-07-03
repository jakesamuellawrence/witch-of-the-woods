using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spells;
using Player;
using Anger;

public class ArpeggioRiff : Spell {

    private readonly float anger_healed = 15;
    private readonly float effect_radius = 15;

    public ArpeggioRiff() {
        activation_code = new Note[] {
            Note.C,
            Note.D,
            Note.E,
            Note.F,
            Note.E,
            Note.D,
            Note.C
        };
    }

    protected override void Activate(PlayerController executing_controller) {
        Debug.Log("Healing Anger!");
        Angry[] angries = Object.FindObjectsOfType<Angry>();
        Debug.Log(angries.Length);
        foreach (Angry angry in angries) {
            if (Vector3.Distance(executing_controller.transform.position, angry.transform.position) < effect_radius) {
                angry.RemoveAnger(anger_healed);
            }
        }
    }
}
