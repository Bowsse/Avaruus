using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelAudioSfx : MonoBehaviour {
    
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        Destroy(gameObject, audio.clip.length);
    }
}
