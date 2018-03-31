namespace Sounds
{
    public interface ISoundPlayer
    {
        void PlayOneShot(string name);
        void Play(string name);
        void Stop();
    }
}
