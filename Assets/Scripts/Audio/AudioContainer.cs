using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioContainer", menuName = "new Audio Container")]
public class AudioContainer : ScriptableObject
{
    public AudioClip RandomClip { get { return _audioClips[Random.Range(0, _audioClips.Length)]; } }

    [SerializeField] private AudioClip[] _audioClips;
}
