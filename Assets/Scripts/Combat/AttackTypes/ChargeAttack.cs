using CreatureProperties;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace AttackTypes {
    [CreateAssetMenu(fileName = "ChargeAttack", menuName = "Attacks/ChargeAttack")]
    public class ChargeAttack : Attack {

        public float charge_distance;
        public float charge_time;

        public override float range {
            get {
                return charge_distance;
            }
        }

        protected override IEnumerator DoAttack() {
            executing_controller.SetBusy(true);

            // play wind up animation
            SpriteRenderer renderer = executing_controller.GetComponentInChildren<SpriteRenderer>();
            Color old_color = renderer.color;
            renderer.color = Color.blue;
            yield return new WaitForSeconds(wind_up_time);
            renderer.color = old_color;

            Vector2 facing = executing_controller.GetFacing();
            Vector3 facing3d = new Vector3(facing.x, facing.y, 0);

            float charge_speed = charge_distance / charge_time;
            float distance_travelled = 0;
            bool has_collided = false;

            while (distance_travelled < charge_distance && has_collided == false) {
                // Move
                float to_move_this_tick = charge_speed * Time.deltaTime;
                executing_controller.transform.position = executing_controller.transform.position + facing3d * to_move_this_tick;
                distance_travelled += to_move_this_tick;

                // Check for hits
                Collider2D[] colliders = Physics2D.OverlapCircleAll(executing_controller.transform.position + facing3d * distance, radius);
                foreach (Collider2D collider in colliders) {
                    Killable killable = collider.GetComponent<Killable>();
                    if (executing_controller.GetComponent<Collider2D>() != collider) {
                        has_collided = true;
                        if (killable != null && !killable.dead) {
                            killable.Damage(hitDamage);
                        }
                    }
                }
                yield return null;
            }

            yield return new WaitForSeconds(wind_down_time);
            executing_controller.SetBusy(false);
        }
    }
}