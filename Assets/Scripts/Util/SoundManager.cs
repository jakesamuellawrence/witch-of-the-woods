using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    #region singleton

    public static SoundManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField]
    private GameObject sound_effect_prefab = null;

    public void Play(AudioClip clip) {
        GameObject sfx = Instantiate(sound_effect_prefab, transform);
        sfx.GetComponent<SoundEffect>().Play(clip);
    }

    public void Play(AudioClip clip, Vector3 position) {
        GameObject sfx = Instantiate(sound_effect_prefab, position, Quaternion.identity);
        sfx.GetComponent<SoundEffect>().Play(clip);
    }

}
