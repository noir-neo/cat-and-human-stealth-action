using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sounds
{
    [CreateAssetMenuAttribute]
    public class AudioAssets : ScriptableObject
    {
        [Serializable]
        class AudioClipName
        {
            [SerializeField] private string _name;
            [SerializeField] private AudioClip _audioClip;
            public string Name => _name;
            public AudioClip AudioClip => _audioClip;
        }

        [SerializeField] private List<AudioClipName> _audioClipNames;
        private Dictionary<string, AudioClip> _audioClips;

        public Dictionary<string, AudioClip> AudioClips()
        {
            return _audioClips ?? (_audioClips = _audioClipNames.ToDictionary(x => x.Name, x => x.AudioClip));
        }
    }
}
