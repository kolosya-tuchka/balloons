namespace Core.Services.AudioService
{
    public interface IAudioService
    {
        void PlayMusic();
        void PlaySoundByType(SoundType soundType);
    }
}