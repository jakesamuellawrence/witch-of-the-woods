using Anger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerStateUI : MonoBehaviour {

    public Sprite[] anger_state_sprites;

    private Image image;
    private Angry angry;

    private void Awake() {
        image = GetComponent<Image>();
        angry = GetComponentInParent<Angry>();
        if (angry == null) {
            Debug.LogError("AngerStateUI was attached to entity with no Angry component");
        }
    }

    private void Update() {
        image.sprite = anger_state_sprites[(int)angry.anger_state];
    }

}
