using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public bool IsBossBattle;

    [SerializeField] private AudioClip _normalMusic, _bossMusic;
    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        AudioClip clip = (IsBossBattle) ? _bossMusic : _normalMusic;
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
