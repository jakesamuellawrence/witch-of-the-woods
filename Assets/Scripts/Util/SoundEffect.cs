using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour {

    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip) {
        source.clip = clip;
        source.Play();
        float duration = clip.length;
        StartCoroutine(DestroyAfterDuration(duration));
    }

    private IEnumerator DestroyAfterDuration(float duration) {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

}
