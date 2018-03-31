using UnityEngine;

namespace Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour, ISoundPlayer
    {
        [SerializeField] private AudioSource _bgmSource;
        [SerializeField] private AudioSource _seSource;

        [SerializeField] private AudioAssets _audioAssets;

        public void PlayOneShot(string name)
        {
            if (_seSource == null) return;
            AudioClip clip;
            if (_audioAssets.AudioClips().TryGetValue(name, out clip))
            {
                _seSource.PlayOneShot(clip);
            }
        }

        public void Play(string name)
        {
            if (_bgmSource == null) return;
            Stop();
            AudioClip clip;
            if (_audioAssets.AudioClips().TryGetValue(name, out clip))
            {
                _bgmSource.clip = clip;
                _bgmSource.Play();
            }
        }

        public void Stop()
        {
            if (_bgmSource == null) return;
            _bgmSource.Stop();
        }
    }
}
