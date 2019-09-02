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

    // Start is called before the first frame update
    void Start()
    {
        //- Add the audio source
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _source)
    {
        _audioSource.PlayOneShot(_source, 1f);
    }

    //- Testing
    void Update()
    {
        if (_debug && Input.anyKeyDown)
        {
            PlaySound(_audioClip);
        }
    }
}
