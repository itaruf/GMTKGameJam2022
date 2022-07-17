using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _currentPitch=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        Event.current._onHalfWayMinGame += SpeedUpMusic;
        Event.current._onCrucialTimeMinGame += SpeedUpMusic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpeedUpMusic()
    {
        if (_currentPitch <= 1.0)
        {
            _currentPitch += 0.25f;
        }
        else if (_currentPitch > 1)
        {
            _currentPitch += 0.25f;
        }

        _audioSource.pitch = _currentPitch;
    }
}
