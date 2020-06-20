using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatureProperties;

public class PlayerKillable : Killable {

    public override void Die() {
        base.Die();
        Debug.Log("YOU DIED");
        gameObject.SetActive(false);
    }

}
