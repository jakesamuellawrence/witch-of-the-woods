using AI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Util;
using CreatureProperties;
using System.Security.Cryptography;

namespace AttackTypes {
    [CreateAssetMenu(fileName = "SlashAttack", menuName = "Attacks/SlashAttack")]
    public class SlashAttack : Attack {

        public GameObject slash_effect_prefab;

        protected override IEnumerator DoAttack() {
            executing_controller.SetBusy(true);

            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips) {
                if (clip.name == "slash_right_windup") {
                    animator.SetFloat("WindupSpeed", clip.length / wind_up_time);
                } else if (clip.name == "slash_right_activation") {
                    animator.SetFloat("ActivationSpeed", clip.length / activation_time);
                }
            }
            animator.SetTrigger("Slash");
            SpriteRenderer renderer = executing_controller.GetComponentInChildren<SpriteRenderer>();
            Color old_color = renderer.color;
            renderer.color = Color.red;
            yield return new WaitForSeconds(wind_up_time);
            renderer.color = old_color;

            Vector2 facing = executing_controller.GetFacing();
            Vector2 position2d = new Vector2(executing_controller.transform.position.x, executing_controller.transform.position.y);

            GameObject slash_effect = Instantiate(slash_effect_prefab, position2d + facing * distance, Quaternion.identity, executing_controller.transform);
            if (slash_effect.transform.localPosition.x <= 0) {
                slash_effect.transform.localScale = new Vector3(-1, 1, 1);
            }
            Vector3 look_at_target = position2d;
            slash_effect.transform.up = look_at_target - slash_effect.transform.position; // point towards attacker
            Animator slash_effect_animator = slash_effect.GetComponent<Animator>();
            float slash_effect_length = slash_effect_animator.runtimeAnimatorController.animationClips[0].length;
            slash_effect_animator.SetFloat("Speed", slash_effect_length / activation_time);

            float current_activation_time = 0;
            bool has_hit = false;
            while (current_activation_time < activation_time && has_hit == false) {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(position2d + facing * distance, radius);
                foreach (Collider2D collider in colliders) { 
                    Killable killable = collider.GetComponent<Killable>();
                    if (collider != executing_controller.GetComponent<Collider2D>() && killable != null) {
                        killable.Damage(hitDamage);
                        has_hit = true;
                    }
                }

                current_activation_time += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(activation_time - current_activation_time);
            GameObject.Destroy(slash_effect);


            yield return new WaitForSeconds(wind_down_time);
            executing_controller.SetBusy(false);
        }

    }
}
