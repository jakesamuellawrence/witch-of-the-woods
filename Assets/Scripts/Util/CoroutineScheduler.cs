using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util {
    public class CoroutineScheduler : MonoBehaviour {

        #region Singleton

        public static CoroutineScheduler instance;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                throw new UnityException("Multiple game managers exist");
            }
        }

        #endregion

        new public void StartCoroutine(IEnumerator coroutine) {
            base.StartCoroutine(coroutine);
        }

        new public void StopCoroutine(IEnumerator coroutine) {
            base.StopCoroutine(coroutine);
        }

        public IEnumerator WaitForSeconds(float time) {
            yield return new WaitForSeconds(time);
        }

    }
}