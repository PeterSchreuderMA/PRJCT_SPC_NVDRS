using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundEmitterInit : MonoBehaviour
{
    AudioSource _audioSource;


    [SerializeField]
    bool _debug = false;

    [SerializeField]
    AudioClip _audioClip;

    [SerializeField]
    [Range(0, 1)]
    float _volume = 1;

    // Start is called before the first frame update
    void Awake()
    {
        //- Add the audio source
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_audioClip, _volume);
    }

    //- Testing
    void Update()
    {
        if (_debug && Input.anyKeyDown)
        {
            PlaySound();
        }
    }
}
