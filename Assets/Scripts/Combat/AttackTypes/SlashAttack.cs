using AI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Util;
using CreatureProperties;

namespace AttackTypes {
    [CreateAssetMenu(fileName = "SlashAttack", menuName = "Attacks/SlashAttack")]
    public class SlashAttack : Attack {

        protected override IEnumerator DoAttack() {
            executing_controller.SetBusy(true);

            // play wind up animation
            SpriteRenderer renderer = executing_controller.GetComponentInChildren<SpriteRenderer>();
            Color old_color = renderer.color;
            renderer.color = Color.red;
            yield return new WaitForSeconds(wind_up_time);
            renderer.color = old_color;

            Vector2 facing = executing_controller.GetFacing();
            Vector2 position2d = new Vector2(executing_controller.transform.position.x, executing_controller.transform.position.y);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(position2d + facing * distance, radius);
            foreach (Collider2D collider in colliders) { 
                Killable killable = collider.GetComponent<Killable>();
                if (collider != executing_controller.GetComponent<Collider2D>() && killable != null) {
                    killable.Damage(damage);
                }
            }

            yield return new WaitForSeconds(wind_down_time);
            executing_controller.SetBusy(false);
        }

    }
}
