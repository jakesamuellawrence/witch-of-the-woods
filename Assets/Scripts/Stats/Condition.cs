using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Conditions {
    public abstract class Condition {

        public Condition(float duration, StatBlock calling_statblock, string id) {
            this.duration = duration;
            this.calling_statblock = calling_statblock;
            this.id = id;
        }

        public string id;

        protected StatBlock calling_statblock;

        private float duration;
        private IEnumerator cancel_after_seconds_coroutine;

        public virtual void StartCondition() {
            cancel_after_seconds_coroutine = CancelConditionAfterSeconds(duration);
            CoroutineScheduler.instance.StartCoroutine(cancel_after_seconds_coroutine);
        }

        public virtual void TickCondition() {}

        public virtual void EndCondition() {
            CoroutineScheduler.instance.StopCoroutine(cancel_after_seconds_coroutine);
            calling_statblock.RemoveCondition(this);
        }

        private IEnumerator CancelConditionAfterSeconds(float seconds) {
            yield return CoroutineScheduler.instance.WaitForSeconds(seconds);
            EndCondition();
        }

    }
}